using System.ComponentModel.DataAnnotations;
namespace DataAnnotationsExtensions.Web.Models
{
    public class EmailEntity
    {
        [Email]
        [Required]
        public string Email { get; set; }
    }
}