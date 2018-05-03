using DataAccessLayer.EF;
using DataAccessLayer.NHibernate;
using Microsoft.AspNet.Identity;
using Models.DataObjects;

namespace DataAccessLayer
{
    public class RepositoryFactory
    {
        public static bool IsEf = false;
        public static IRepository<T> EntityRepo<T>() where T : class
        {
            if (IsEf)
            {
                return new EFRepository<T>();
            }
            return new NHibernateRepository<T>();
        }
    }
}