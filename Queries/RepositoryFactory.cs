using Queries.Controllers;
using Queries.Models;
using Queries.Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Queries
{
    public static class RepositoryFactory
    {
        public static bool IsEf = false;
        public static IRepository<User> Users()
        {
            if (IsEf)
            {
                return new EFRepository<User>();
            }
            return new NHibernateRepository<User>();
        }

        public static IRepository<Query> Queries()
        {
            if (IsEf)
            {
                return new EFRepository<Query>();
            }
            return new NHibernateRepository<Query>();
        }
    }
}