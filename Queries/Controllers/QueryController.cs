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
    //1) Разделить слой доступа к данным, сервисы, константы и веб-сайт по разным проектам
    //2) Фабричный класс сделать более универсальным по отношению к количеству сущностей
    //3) В контроллерах использовать модель Post/Redirect/Get
    //4) Валидацию данных(Login) вынести из контроллера
    //5) При регистрации пользователя добавить поле "Дата рождения"
    //6) Добавить валидацию, что пользователю больше 18 лет
    //7) Избавиться от неиспользуемых в проекте скриптов
    //8) Использовать Auto или Fluent маппинг для NHibernate
    //9) Factory в NHibernate должен создаваться только один раз

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
                //using (RegistrationService registry = new RegistrationService())
                //{
                //    try
                //    {
                //        ViewBag.QueryId = registry.Save(newQuery).Id;
                //    }
                //    catch
                //    {
                //        return View();
                //    }
                //}

                RegistrationService registry = new RegistrationService();

                ViewBag.QueryId = registry.Save(newQuery).Id;

            }
            return View();
        }
    }
}