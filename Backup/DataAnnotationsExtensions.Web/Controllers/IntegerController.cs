using DataAnnotationsExtensions.Core;

namespace DataAnnotationsExtensions.Web.Controllers
{
    public class IntegerController : ValidationControllerBase<IntegerEntity>
    {
        protected override void AddMessage()
        {
            Message = "Integer Validation: Digits only except a negative sign is optionally allowed.";
        }
    }
}
