using DataAnnotationsExtensions.Core;

namespace DataAnnotationsExtensions.Web.Controllers
{
    public class UrlController : ValidationControllerBase<UrlEntity>
    {
        protected override void AddMessage()
        {
            Message =
                "The first Url field requires a fully-qualified Url (default), the second makes the protocol optional, and the third explicitly disallows entering the protocol";
        }
    }
}