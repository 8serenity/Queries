using DataAccessLayer;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Models.DataObjects;
using Owin;
using Queries.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Queries
{
    public partial class Startup
    {
        public void ConfigureAuth(IAppBuilder app)
        {
            //app.CreatePerOwinContext<AppIdentityDbContext>(AppIdentityDbContext.Create);
            app.CreatePerOwinContext<AppUserManager>(AppUserManager.Create);
            //Везде где требуется интерфейс...
            app.CreatePerOwinContext<IUserStore<AppUser, string>>(() => new MyUserStore());

            app.CreatePerOwinContext<SignInManager>((options, context) => new SignInManager(context.GetUserManager<AppUserManager>(), context.Authentication));
            
            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                LoginPath = new PathString("/Account/Login")
            });
            app.UseExternalSignInCookie(DefaultAuthenticationTypes.ExternalCookie);
        }
    }
}