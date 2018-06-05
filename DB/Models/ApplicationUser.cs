
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

using Microsoft.AspNetCore.Identity;

namespace DB.Models
{
    public partial class ApplicationUser : IdentityUser<Int32>
    {
        public ApplicationUser()
        {
            Table1s = new HashSet<Table1>();
        }

        [Required]
        [MaxLength(50)]
        public String Name { get; set; }

        public ICollection<Table1> Table1s { get; set; }
    }
}