using Microsoft.AspNet.Identity.Owin;
using Models.ViewModels;
using Queries.Infrastructure;
using System.Web;
using System.Web.Mvc;

namespace Queries.Controllers
{
    public class CreateAjaxController : Controller

    {
        public SignInManager SignInManager
        {
            get { return HttpContext.GetOwinContext().Get<SignInManager>(); }
        }

        //private SignInManager _manager;
        //public CreateAjaxController(SignInManager manager)
        //{
        //    _manager = manager;
        //}
        // GET: CreateAjax
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public JsonResult Index(UserLoginView userToCheck)
        {
            //User.Identity.Name отсюда доставешь инфу кто залогинен и показываешь ему инфу основанную на этом

            if (!ModelState.IsValid)
            {
                return new JsonResult()
                {
                    JsonRequestBehavior = JsonRequestBehavior.AllowGet,
                    Data = new { IsSuccess = false }
                };
            }

            //using (RegistrationService registry = new RegistrationService(SignInManager))
            //{
            //    try
            //    {
            RegistrationService registry = new RegistrationService(SignInManager);
            var existedUser = registry.UserValid(userToCheck.Email, userToCheck.Password);
            if (existedUser != null)
            {
                SignInManager.PasswordSignIn(existedUser.UserName, userToCheck.Password, false, false);
                //SignInManager.SignOut();
                var asd = User.Identity.Name;

                return new JsonResult()
                {
                    JsonRequestBehavior = JsonRequestBehavior.AllowGet,
                    Data = new { IsSuccess = true}
                };
            };
            //}
            //catch
            //{
            //    return new JsonResult()
            //    {
            //        JsonRequestBehavior = JsonRequestBehavior.AllowGet,
            //        Data = new { IsSuccess = false}
            //    };


            //return View("Querylist", registry.UserQueries(userToCheck.Id));
            //}

            return new JsonResult()
            {
                JsonRequestBehavior = JsonRequestBehavior.AllowGet,
                Data = new { IsSuccess = false }
            };
            //}
        }
    }
}