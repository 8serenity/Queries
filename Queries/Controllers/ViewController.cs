using System;
using System.Web.Mvc;
using Models.ViewModels;
using Queries.Infrastructure;
using System.Web;
using Microsoft.AspNet.Identity.Owin;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Models.DataObjects;
using System.Collections.Generic;

namespace Queries.Controllers
{
    public class ViewController : Controller
    {
        //public ViewController(SignInManager manager)
        //{
        //    _manager = manager;
        //}

        private SignInManager _manager;
        [HttpGet]
        [ImportModelState]
        public ActionResult Login()
        {
            return View();
        }


        public ActionResult Querylist()
        {
            using (RegistrationService registry = new RegistrationService(_manager))
            {
                if (User.Identity.IsAuthenticated)
                {
                    return View(registry.UserQueries(User.Identity.Name));
                }
                else
                {
                    return View("~/Views/CreateAjax/Index.cshtml");
                }
            }
        }

        [HttpPost]
        [ExportModelState]
        public ActionResult Login(UserLoginView user)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Login");
            }

            RegistrationService registry = new RegistrationService(_manager);

            var userToCheck = registry.UserValid(user.Email, user.Password);
            if (userToCheck !=null)
            {
                //Response.Cookies.Add(new System.Web.HttpCookie("AUTH", Encode(UserId)));
                //var userId = Decode(Request.Cookies["AUTH"].Value);

                return View("Querylist", registry.UserQueries(userToCheck.Id));
            }
            TempData["IsLogged"] = 0;


            return RedirectToAction("Login");

            //using (RegistrationService registry = new RegistrationService())
            //{
            //    try
            //    {
            //        var userToCheck = registry.UserExists(user.Email);
            //        if (registry.UserValid(userToCheck,user.Password))
            //        {
            //            //Response.Cookies.Add(new System.Web.HttpCookie("AUTH", Encode(UserId)));
            //            //var userId = Decode(Request.Cookies["AUTH"].Value);

            //            return View("Querylist", registry.UserQueries(userToCheck.Id));
            //        }
            //        TempData["IsLogged"] = 0;
            //    }
            //    catch
            //    {

            //        return RedirectToAction("Login");
            //    }
            //}
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