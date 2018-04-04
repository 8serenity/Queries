using Models.ViewModels;
using System.Web.Mvc;

namespace Queries.Controllers
{
    public class CreateAjaxController : Controller
    {
        // GET: CreateAjax
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public string Index(QueryView newQuery)
        {
            if (!ModelState.IsValid)
            {
                //return new JsonResult()
                //{
                //    JsonRequestBehavior = JsonRequestBehavior.AllowGet,
                //    Data = new { result = "error" }
                //};
                return "sefsef";

            }

            using (RegistrationService registry = new RegistrationService())
            {
                try
                {
                    //var result = registry.Save(newQuery).Id;
                    //return Json(new { IsSuccess = true, Data = result });
                    //TempData["QueryId"] = registry.Save(newQuery).Id;

                    return registry.Save(newQuery).Id.ToString();

                    //return registry.Save(newQuery).Id.ToString();

                    //return new JsonResult()
                    //{
                    //    JsonRequestBehavior = JsonRequestBehavior.AllowGet,
                    //    Data = new { result = "success" }
                    //};


                    //return new JsonResult()
                    //{
                    //    JsonRequestBehavior = JsonRequestBehavior.AllowGet,
                    //    Data = new { result = 35 }
                    //};
                }
                catch
                {
                    return "sefsef";

                    //return new JsonResult()
                    //{
                    //    JsonRequestBehavior = JsonRequestBehavior.AllowGet,
                    //    Data = new { result = "error" }
                    //};
                }
            }
        }
    }
}