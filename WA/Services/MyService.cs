using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;

using DB;
using DB.Models;
using WA.Models;

namespace WA.Services
{
    public class MyService : IMyService
    {
        private readonly MyDbContext _context;

        public IEnumerable<Table1> Table1sWithAll
        {
            get
            {
                return _context.Table1s
                    .Include(t1 => t1.User)
                    .Include(t1 => t1.Table2)
                        .ThenInclude(t2 => t2.Table3);
            }
        }

        public IEnumerable<Table2> Table2sWithAll
        {
            get
            {
                return _context.Table2s
                    .Include(t2 => t2.Table3)
                    .Include(t2 => t2.Table1s)
                        .ThenInclude(t1 => t1.User);
            }
        }

        public IEnumerable<Table3> Table3sWithAll
        {
            get
            {
                return _context.Table3s
                    .Include(t3 => t3.Table2s)
                        .ThenInclude(t2 => t2.Table1s)
                            .ThenInclude(t1 => t1.User);
            }
        }

        public MyService(MyDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Table3> NarrowTable3sByColumn1(Int32 column1)
        {
            try
            {
                return Table3sWithAll.Where(t3 => (t3.Id == column1));
            }
            catch (Exception)
            {
                return null;
            }
        }

        public IEnumerable<Table3> NarrowTable3sSelection(IEnumerable<Table3> table3s, Int32 from, Int32 pagingSize = 20)
        {
            try
            {
                return table3s.Skip(from).Take(pagingSize);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public Table3 GetTable3ByTable3Id(Int32 table3Id)
        {
            try
            {
                return Table3sWithAll.FirstOrDefault(t3 => t3.Id == table3Id);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public Byte[] GetTable3FileData(Int32 table3Id)
        {
            try
            {
                Table3 table3 = _context.Table3s.FirstOrDefault(t3 => table3Id == t3.Id);

                if (table3 == null)
                {
                    return null;
                }

                return table3.FileData;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public Boolean SaveFileData(Int32 table3Id, Byte[] fileData)
        {
            try
            {
                Table3 table3 = GetTable3ByTable3Id(table3Id);

                if (table3 == null)
                {
                    return false;
                }

                table3.FileData = fileData;
                _context.SaveChanges();

                return true;

            }
            catch (Exception)
            {
                return false;
            }
            
        }
    }
}
