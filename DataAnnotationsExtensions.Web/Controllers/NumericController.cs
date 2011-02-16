using DataAnnotationsExtensions.Core;

namespace DataAnnotationsExtensions.Web.Controllers
{
    public class NumericController : ValidationControllerBase<NumericEntity>
    {
        protected override void AddMessage()
        {
            Message = "Numeric Validation: Any number is allowed, including fractional numbers {ex: 42, 42.24, 0.1, 3.50}";
        }
    }
}
