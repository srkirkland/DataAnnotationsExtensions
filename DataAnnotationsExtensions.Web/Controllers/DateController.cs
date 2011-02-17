using DataAnnotationsExtensions.Core;

namespace DataAnnotationsExtensions.Web.Controllers
{
    public class DateController : ValidationControllerBase<DateEntity>
    {
        protected override void AddMessage()
        {
            Message =
                "Both fields expect a date formatted string.  The DateAsString field shows server-side validation separate from data type checking";
        }
    }
}
