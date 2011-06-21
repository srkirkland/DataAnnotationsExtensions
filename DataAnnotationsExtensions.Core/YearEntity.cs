using System.ComponentModel.DataAnnotations;

namespace DataAnnotationsExtensions.Core
{
    public class YearEntity
    {
        [Year]
        [Required]
        public int Year { get; set; }

        [Year]
        [Required]
        public string YearAsString { get; set; }
    }
}