namespace DataAnnotationsExtensions.Core
{
    public class FileExtensionsEntity
    {
        [FileExtensions] //Using defaults
        public string ImageFileName { get; set; }

        [FileExtensions("doc|docx|txt|rtf|pdf")]
        public string DocumentFileName { get; set; }
    }
}
