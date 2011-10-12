using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace DataAnnotationsExtensions.Core
{
    public class GreaterThanEntity
    {
        [Required]
        [Display(Name = "LesserDisplayName")]
        public DateTime Lesser { get; set; }

        [GreaterThan("Lesser")]
        [Required]
        public DateTime Greater { get; set; }
    }
}
