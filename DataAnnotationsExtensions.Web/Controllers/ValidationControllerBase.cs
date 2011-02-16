using System.Web.Mvc;

namespace DataAnnotationsExtensions.Web.Controllers
{
    public abstract class ValidationControllerBase<T> : Controller where T : new()
    {
        protected string Message { set { TempData["Message"] = value; } }
        protected virtual void AddMessage() {}

        public ActionResult Create()
        {
            AddMessage();

            return View(new T());
        }

        [HttpPost]
        public ActionResult Create(T entity)
        {
            AddMessage();

            if (!ModelState.IsValid)
            {
                return View(entity);
            }

            TempData["Message"] = "Entity Saved Successfully";
            return RedirectToAction("Index", "Home");
        }
    }
}
