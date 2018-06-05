using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace DB.Models
{
    public partial class Table2
    {
        public Table2()
        {
            Table1s = new HashSet<Table1>();
        }

        [Key]
        public Int32 Id { get; set; }

        [Required]
        [DisplayName("Table3")]
        public Int32 Table3Id { get; set; }

        public virtual Table3 Table3 { get; set; }

        public ICollection<Table1> Table1s { get; set; }
    }
}
