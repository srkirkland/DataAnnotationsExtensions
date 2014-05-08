using System.Linq;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;

namespace DataAnnotationsExtensions.Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Message = "Welcome to ASP.NET MVC!";

            return View();
        }
 
        public ActionResult Demos()
        {
            return View();
        }

        public ActionResult Download()
        {
            return View();
        }

        public ActionResult Wiki()
        {
            return View();
        }

        [ChildActionOnly]
        public ActionResult AttributeList()
        {
            var validationAttributeAssembly = typeof(EmailAttribute).Assembly;
            var validationAttributes = validationAttributeAssembly.GetTypes().Where(x => x.IsSubclassOf(typeof(ValidationAttribute)));

            validationAttributes.Select(x => new { x.Name, Controller = x.Name.Substring(0, x.Name.Length - "attribute".Length) });

            return PartialView("_AttributeList", validationAttributes);
        }


        public ActionResult About()
        {
            return View();
        }
    }
}
