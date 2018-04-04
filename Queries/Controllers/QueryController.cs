using Models.ViewModels;
using System.Web.Mvc;

namespace Queries.Controllers
{

    public class QueryController : Controller
    {

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
                //return Json("ERROR");
                return RedirectToAction("Create");
            }


            using (RegistrationService registry = new RegistrationService())
            {
                try
                {
                    //var result = registry.Save(newQuery).Id;
                    //return Json(new { IsSuccess = true, Data = result });
                    TempData["QueryId"] = registry.Save(newQuery).Id;
                }
                catch
                {
                    return View();
                }
            }


            return RedirectToAction("Create");
        }
    }
}