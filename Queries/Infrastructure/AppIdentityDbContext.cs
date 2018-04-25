using Microsoft.AspNet.Identity.EntityFramework;

using System.Data.Entity;

namespace Queries.Infrastructure
{
    //public class AppIdentityDbContext : IdentityDbContext<AppUser>
    //{
    //    public AppIdentityDbContext() : base("DbConnection") { }
    //    static AppIdentityDbContext()
    //    {
    //        Database.SetInitializer<AppIdentityDbContext>(new IdentityDbInit());
    //    }

    //    public static AppIdentityDbContext Create()
    //    {
    //        return new AppIdentityDbContext();
    //    }
    //}

    //public class IdentityDbInit : DropCreateDatabaseIfModelChanges<AppIdentityDbContext>
    //{
    //    protected override void Seed(AppIdentityDbContext context)
    //    {
    //        PerformInitialSetup(context);
    //        base.Seed(context);
    //    }
    //    public void PerformInitialSetup(AppIdentityDbContext context)
    //    {
    //        // настройки конфигурации контекста будут указываться здесь
    //    }
    //}

}