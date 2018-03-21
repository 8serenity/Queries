using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Queries.Models;
using NHibernate;

namespace Queries.Controllers
{
    public class ViewController : Controller
    {
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(UserLoginView user)
        {
            if (ModelState.IsValid)
            {
                using (RegistrationService registry = new RegistrationService())
                {
                    if (registry.UserExists(user.Email) == null || user.Password != registry.UserExists(user.Email).Password)
                    {
                        @ViewBag.IsLogged = 0;
                        return View();
                    }
                    @ViewBag.IsLogged = 1;

                    int userId = registry.UserExists(user.Email).Id;
                    return View("Querylist", registry.UserQueries(userId));
                }

                
            }
            return View();
        }
    }
}