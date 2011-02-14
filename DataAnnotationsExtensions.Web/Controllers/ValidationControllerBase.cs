using System.Web.Mvc;

namespace DataAnnotationsExtensions.Web.Controllers
{
    public abstract class ValidationControllerBase<T> : Controller where T : new()
    {
        public ActionResult Create()
        {
            return View(new T());
        }

        [HttpPost]
        public ActionResult Create(T entity)
        {
            if (!ModelState.IsValid)
            {
                return View(entity);
            }

            TempData["Message"] = "Entity Saved Successfully";
            return RedirectToAction("Index", "Home");
        }
    }
}
