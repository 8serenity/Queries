using System.Web.Mvc;
using Models.ViewModels;

namespace Queries.Controllers
{
    public class ViewController : Controller
    {
        [HttpGet]
        [ImportModelState]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ExportModelState]
        public ActionResult Login(UserLoginView user)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Login");
            }

            using (RegistrationService registry = new RegistrationService())
            {

                try
                {
                    int UserId = registry.UserValid(user);
                    if (UserId != 0)
                    {
                        return View("Querylist", registry.UserQueries(UserId));
                    }
                    //@ViewBag.IsLogged = 0;
                    TempData["IsLogged"] = 0;
                }
                catch
                {

                    return RedirectToAction("Login");
                }
            }

            return RedirectToAction("Login");
        }
    }
}