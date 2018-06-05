using System;
using System.Collections.Generic;

namespace DB.Models.DTOs
{
    public class ApplicationUserDTO
    {
        public ApplicationUserDTO()
        {
            Id = -1;
            Table1DTOs = new List<Table1DTO>();
        }

        public Int32 Id { get; set; }
        public String Name { get; set; }

        public IList<Table1DTO> Table1DTOs { get; set; }

        public override Boolean Equals(Object obj)
        {
            return (obj is ApplicationUserDTO bd) && Id == bd.Id;
        }

        public override Int32 GetHashCode()
        {
            Int32 hash = Id;

            hash = (hash * 654) + Id.GetHashCode();

            return hash;
        }
    }
}
