using DataAnnotationsExtensions.Core;

namespace DataAnnotationsExtensions.Web.Controllers
{
    public class DateController : ValidationControllerBase<DateEntity>
    {
        protected override void AddMessage()
        {
            Message =
                "Both fields expect a date formatted string.  The DateAsString field shows how you can validate a string instead of a DateTime object. If you use [Date] on a DateTime object it will be the same as just setting the data type with [DataType(DataType.Date)]";
        }
    }
}
