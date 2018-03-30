using Models.ViewModels;
using System.Web.Mvc;

namespace Queries.Controllers
{
    
    public class QueryController : Controller
    {

        [HttpGet]
        [ImportModelState]
        public ActionResult Create()
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


            using (RegistrationService registry = new RegistrationService())
            {
                try
                {
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