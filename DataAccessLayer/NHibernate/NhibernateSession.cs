using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;

namespace DataAccessLayer.NHibernate
{
    public class NhibernateSession
    {
        private static ISessionFactory _sessionFactory;

        public static void InitializeSessionFactory()
        {
            _sessionFactory = Fluently.Configure()
                .Database(MsSqlConfiguration.MsSql2012
                .ConnectionString(@"Server=DESKTOP-OP0BNT2\SQLEXPRESS; Database=queriesDB; Integrated Security=SSPI;"))
                .Mappings(m => m
                .FluentMappings.AddFromAssemblyOf<UserMap>())
                .BuildSessionFactory();
        }

        public static ISession OpenSession()
        {
            return SessionFactory.OpenSession();
        }

        private static ISessionFactory SessionFactory
        {
            get
            {
                if (_sessionFactory == null)
                    InitializeSessionFactory();
                return _sessionFactory;
            }
        }
    }
}