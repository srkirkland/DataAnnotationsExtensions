using DataAnnotationsExtensions.Core;

namespace DataAnnotationsExtensions.Web.Controllers
{
    public class CreditCardController : ValidationControllerBase<CreditCardEntity>
    {
        protected override void AddMessage()
        {
            Message =
                "Credit Card validation:  Examples of valid values {1234567890123452, 1234-5678-9012-3452, 4408041234567893}. Dashes and spaces are allowed.";
        }
    }
}