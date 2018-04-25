using System.Data.Entity;
using Models.DataObjects;
using Microsoft.AspNet.Identity.EntityFramework;

namespace DataAccessLayer.EF
{
    public class QueriesContext : DbContext
    {
        public QueriesContext(): base("DbConnection")
        {
            
        }

        public DbSet<AppUser> AspNetUsers { get; set; }
        public DbSet<Query> Queries { get; set; }

    }
}