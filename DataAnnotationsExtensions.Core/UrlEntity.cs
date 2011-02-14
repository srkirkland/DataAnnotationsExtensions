using System.ComponentModel.DataAnnotations;

namespace DataAnnotationsExtensions.Core
{
    public class UrlEntity
    {
        [Url]
        [Required]
        public string Url { get; set; }
    }
}