using NHibernate;
using Queries.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Queries.Controllers
{


    public class QueryController : Controller
    {

        public ActionResult Create()
        {
            return View();
        }

        

        [HttpPost]
        public ActionResult Create(QueryView newQuery)
        {
            if (ModelState.IsValid)
            {
                using (RegistrationService registry = new RegistrationService())
                {
                    try
                    {
                        ViewBag.QueryId = (registry.Save(newQuery) as Query).Id;
                    }
                    catch
                    {
                        return View();
                    }
                }
            }
            return View();
        }
    }
}