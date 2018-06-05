using System;
using System.Collections.Generic;
using System.Text;

namespace DB.Models.DTOs
{
    public class Table3DTO
    {
        public Int32 Id { get; set; }
        public Byte[] FileData { get; set; }

        public IList<Table2DTO> Table2DTOs { get; set; }

        public Table3DTO()
        {
            Id = -1;
            Table2DTOs = new List<Table2DTO>();
        }

        public override Boolean Equals(Object obj)
        {
            return (obj is Table3DTO bd) && Id == bd.Id;
        }

        public override Int32 GetHashCode()
        {
            Int32 hash = Id;

            hash = (hash * 852) + Id.GetHashCode();

            return hash;
        }
    }
}
