using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataAnnotationsExtensions.Core;

namespace DataAnnotationsExtensions.Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Message = "Welcome to ASP.NET MVC!";

            return View();
        }

        public ActionResult Email()
        {
            return View(new EmailEntity());
        }

        [HttpPost]
        public ActionResult Email(EmailEntity emailEntity)
        {
            if (!ModelState.IsValid)
            {
                return View(emailEntity);
            }

            return RedirectToAction("Index");
        }

        public ActionResult About()
        {
            return View();
        }
    }
}
