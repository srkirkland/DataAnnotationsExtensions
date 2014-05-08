using DataAnnotationsExtensions.Core;

namespace DataAnnotationsExtensions.Web.Controllers
{
    public class YearController : ValidationControllerBase<YearEntity>
    {
        protected override void AddMessage()
        {
            Message =
                "Year validation:  Examples of valid values {2011, 1999}.";
        }
    }
}