using System;
using System.Collections.Generic;
using System.Text;

namespace DB.Models.DTOs
{
    public class Table1DTO
    {
        public Int32 Id { get; set; }
        public ApplicationUserDTO VolumeData { get; set; }
        public Table2DTO Table2DTOs { get; set; }

        public Table1DTO()
        {
            Id = -1;
        }

        public override Boolean Equals(Object obj)
        {
            return (obj is Table1DTO bd) && Id == bd.Id;
        }

        public override Int32 GetHashCode()
        {
            Int32 hash = Id;

            hash = (hash * 321) + Id.GetHashCode();

            return hash;
        }

    }
}
