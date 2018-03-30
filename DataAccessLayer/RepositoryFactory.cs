using DataAccessLayer.EF;
using DataAccessLayer.NHibernate;

namespace DataAccessLayer
{
    public static class RepositoryFactory
    {
        public static bool IsEf = true;
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