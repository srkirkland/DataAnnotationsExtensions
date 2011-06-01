using System.ComponentModel.DataAnnotations;

namespace DataAnnotationsExtensions.Core
{
    public class CuitEntity
    {
        [Cuit]
        [Required]
        public string Cuit { get; set; }
    }
}