using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Cfg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Queries.Models
{
    public class NhibernateSession
    {
        //public static ISession OpenSession()
        //{
        //    var configuration = new Configuration();
        //    var configurationPath = HttpContext.Current.Server.MapPath(@"~\Models\Nhibernate\hibernate.cfg.xml");
        //    configuration.Configure(configurationPath);
        //    var queryConfigurationFile = HttpContext.Current.Server.MapPath(@"~\Mappings\Query.hbm.xml");
        //    configuration.AddFile(queryConfigurationFile);
        //    ISessionFactory sessionFactory = configuration.BuildSessionFactory();
        //    return sessionFactory.OpenSession();



        //}

        private static ISessionFactory _sessionFactory;

        private static void InitializeSessionFactory()
        {
            _sessionFactory = Fluently.Configure()
                .Database(MsSqlConfiguration.MsSql2012
                .ConnectionString(@"Server=DESKTOP-OP0BNT2\SQLEXPRESS; Database=queriesDB; Integrated Security=SSPI;"))
                .Mappings(m => m
                .FluentMappings.AddFromAssemblyOf<User>())
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