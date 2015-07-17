using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHbApp.Domain;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Dialect;
using NHibernate.Tool.hbm2ddl;

namespace NHbApp.Infrastructure
{
    public static class NHibernateHelpers
    {
        //private const string ConnectionString = @"Data Source=LOCALHOST\SQL2012R2;Initial Catalog=NHbContext;Integrated Security=True";
        private const string ConnectionString = @"Data Source=LOCALHOST\SQLEXPRESS;Initial Catalog=NHbContext;Integrated Security=True";


        private static ISessionFactory _sessionFactory;

        private static ISessionFactory SessionFactory
        {
            get { return _sessionFactory ?? (_sessionFactory = CreateSessionFactory()); }
        }

        public static ISession OpenSession()
        {
            return SessionFactory.OpenSession();
        }

        private static FluentConfiguration GetConfiguration()
        {
            return Fluently.Configure()
                .Database(
                    MsSqlConfiguration.MsSql2012.ConnectionString(ConnectionString))
                .Mappings(m => m.FluentMappings.AddFromAssemblyOf<Person>());
        }

        private static ISessionFactory CreateSessionFactory()
        {
            
            return GetConfiguration()
                .BuildSessionFactory();
        }

        public static void GenerateDatabase(bool script,bool export,bool justDrop)
        {
            GetConfiguration()
                .ExposeConfiguration(c => new SchemaExport(c).Execute(script, export, justDrop))
                .BuildConfiguration();
        }
    }
}
