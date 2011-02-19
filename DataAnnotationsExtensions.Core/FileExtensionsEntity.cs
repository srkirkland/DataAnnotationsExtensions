using System.ComponentModel.DataAnnotations;
namespace DataAnnotationsExtensions.Core
{
    public class FileExtensionsEntity
    {
        [FileExtensions] //Using defaults
        [Required]
        public string ImageFileName { get; set; }

        [FileExtensions("doc|docx|txt|rtf|pdf")]
        [Required]
        public string DocumentFileName { get; set; }
    }
}
