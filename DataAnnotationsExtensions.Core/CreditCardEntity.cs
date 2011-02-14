using System.ComponentModel.DataAnnotations;

namespace DataAnnotationsExtensions.Core
{
    public class CreditCardEntity
    {
        [CreditCard]
        [Required]
        public string CreditCard { get; set; }
    }
}