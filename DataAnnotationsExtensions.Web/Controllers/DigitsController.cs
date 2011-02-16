using DataAnnotationsExtensions.Core;

namespace DataAnnotationsExtensions.Web.Controllers
{
    public class DigitsController : ValidationControllerBase<DigitsEntity>
    {
        protected override void AddMessage()
        {
            Message = "Digits Validation: Only digits are allowed.";
        }
    }
}
