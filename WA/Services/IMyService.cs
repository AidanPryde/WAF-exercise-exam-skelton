using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using DB.Models;
using WA.Models;

namespace WA.Services
{
    public enum UpdateResult
    {
        Success,
        ConcurrencyError,
        DbError
    }

    public interface IMyService
    {
        IEnumerable<Table1> Table1sWithAll { get; }
        IEnumerable<Table2> Table2sWithAll { get; }
        IEnumerable<Table3> Table3sWithAll { get; }

        IEnumerable<Table3> NarrowTable3sByColumn1(Int32 column1);
        IEnumerable<Table3> NarrowTable3sSelection(IEnumerable<Table3> table3s, Int32 from, Int32 pagingSize = 20);

        Table3 GetTable3ByTable3Id(Int32 table3Id);
        Byte[] GetTable3FileData(Int32 table3Id);
    }
}
