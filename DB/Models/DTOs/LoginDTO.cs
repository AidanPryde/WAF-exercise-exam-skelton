using System;
using System.ComponentModel.DataAnnotations;

namespace DB.Models.DTOs
{
    public class LoginDTO
    {
        [Required]
        public String UserName { get; set; }
        [Required]
        public String Password { get; set; }
    }
}
