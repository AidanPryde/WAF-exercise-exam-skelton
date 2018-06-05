using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace DB.Models
{
    public partial class Table1
    {
        [Key]
        public Int32 Id { get; set; }

        [DisplayName("Table2")]
        public Int32 Table2Id { get; set; }

        [DisplayName("User")]
        public Int32 UserId { get; set; }

        public virtual Table2 Table2 { get; set; }
        public virtual ApplicationUser User { get; set; }
    }
}
