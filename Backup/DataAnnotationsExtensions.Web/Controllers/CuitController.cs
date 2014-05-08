using DataAnnotationsExtensions.Core;

namespace DataAnnotationsExtensions.Web.Controllers
{
    public class CuitController : ValidationControllerBase<CuitEntity>
    {
        protected override void AddMessage()
        {
            Message =
                "CUIT validation:  Examples of valid values {20245597151, 20-24559715-1}.";
        }
    }
}