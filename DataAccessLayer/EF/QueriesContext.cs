using System.Data.Entity;
using Models.DataObjects;

namespace DataAccessLayer.EF
{
    public class QueriesContext : DbContext
    {
        public QueriesContext(): base("DbConnection")
        {
            
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Query> Queries { get; set; }

    }
}