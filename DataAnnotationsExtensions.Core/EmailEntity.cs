using System.ComponentModel.DataAnnotations;

namespace DataAnnotationsExtensions.Core
{
    public class EmailEntity
    {
        [Email]
        [Required]
        public string Email { get; set; }
    }
}