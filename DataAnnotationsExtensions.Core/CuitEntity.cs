using System.ComponentModel.DataAnnotations;

namespace DataAnnotationsExtensions.Core
{
    public class CuitEntity
    {
        [Required]
        [RegularExpression(Expressions.Cuit)]
        public string Cuit { get; set; }
    }
}