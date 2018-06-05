using System;
using System.ComponentModel.DataAnnotations;

namespace WA.Models
{
    public class SearchViewModel
    {
        [RegularExpression("^[0-9]$", ErrorMessage = "The given Column1 has a wrong format, or too long.")]
        public Int32 Column1 { get; set; }
    }
}
