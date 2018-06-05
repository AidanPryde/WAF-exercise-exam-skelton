using System;
using System.ComponentModel.DataAnnotations;

namespace WA.Models
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "You must fill out the username field.")]
        public String Username { get; set; }

        [Required(ErrorMessage = "You must fill out the password field.")]
        [DataType(DataType.Password)]
        public String UserPassword { get; set; }

        public Boolean RememberLogin { get; set; }
    }
}
