using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace DataAnnotationsExtensions.Core
{
    public class EqualToEntity
    {
        [Required]
        [Display(Name = "PrimaryDisplayName")]
        public string Primary { get; set; }

        [EqualTo("Primary")]
        [Required]
        public string Confirm { get; set; }
    }
}
