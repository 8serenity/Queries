using System;
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
                        //Response.Cookies.Add(new System.Web.HttpCookie("AUTH", Encode(UserId)));
                        //var userId = Decode(Request.Cookies["AUTH"].Value);
                        return View("Querylist", registry.UserQueries(UserId));
                    }
                    TempData["IsLogged"] = 0;
                }
                catch
                {

                    return RedirectToAction("Login");
                }
            }

            return RedirectToAction("Login");
        }

        //private long Decode(string value)
        //{
        //    throw new NotImplementedException();
        //}

        //private string Encode(int userId)
        //{
        //    throw new NotImplementedException();
        //    // AspNet Identity -> UserManager -> IUserStore(RepositoryFactory)
        //    // EF Identity - IdentityContext
        //    // IdentityUser, Guid Id ...
        //}
    }
}