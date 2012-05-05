using System.ComponentModel.DataAnnotations;

namespace DataAnnotationsExtensions.Core
{
    public class UrlEntity
    {
        [Url]
        [Required]
        public string Url { get; set; }
        
        [Url(UrlOptions.OptionalProtocol)]
        [Required]
        public string UrlWithoutProtocolRequired { get; set; }

        [Url(UrlOptions.DisallowProtocol)]
        [Required]
        public string UrlDisallowProtocol { get; set; }
    }
}