using System;
using System.Collections.Generic;
using System.Text;

namespace DB.Models.DTOs
{
    public class Table2DTO
    {
        public Int32 Id { get; set; }
        public IList<Table1DTO> Table1DTOs { get; set; }

        public Table2DTO()
        {
            Id = -1;
            Table1DTOs = new List<Table1DTO>();
        }

        public override Boolean Equals(Object obj)
        {
            return (obj is Table2DTO bd) && Id == bd.Id;
        }

        public override Int32 GetHashCode()
        {
            Int32 hash = Id;

            hash = (hash * 741) + Id.GetHashCode();

            return hash;
        }
    }
}
