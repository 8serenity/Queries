using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace Queries.Models.EF
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