using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace DB.Models
{
    public partial class Table3
    {
        public Table3()
        {
            Table2s = new HashSet<Table2>();
        }

        [Key]
        public Int32 Id { get; set; }
        public Byte[] FileData { get; set; }

        public ICollection<Table2> Table2s { get; set; }
    }
}
