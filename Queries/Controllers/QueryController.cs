using Microsoft.AspNet.Identity.Owin;
using Models.DataObjects;
using Models.ViewModels;
using Queries.Infrastructure;
using System.Web;
using System.Web.Mvc;

namespace Queries.Controllers
{

    public class QueryController : Controller
    {


        public SignInManager SignInManager
        {
            get { return HttpContext.GetOwinContext().Get<SignInManager>(); }
        }
        //private SignInManager _manager;

        //public QueryController( SignInManager <AppUser,string> signInManager)
        //{
        //    _manager = manager;
        //}

        [HttpGet]
        [ImportModelState]
        //public ActionResult Create(long? newAppealId = null) instead of using TempData
        public ActionResult Create(long? newAppealId = null)
        {
            return View();
        }


        [HttpPost]
        [ExportModelState]
        public ActionResult Create(QueryView newQuery)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Create");
            }

            RegistrationService registry = new RegistrationService(SignInManager);

            //using (RegistrationService registry = new RegistrationService())
            //{
            //    try
            //    {
            TempData["QueryId"] = registry.Save(newQuery).Id;
            //    }
            //    catch
            //    {
            //        return View();
            //    }
            //}


            return RedirectToAction("Create");
        }
    }
}