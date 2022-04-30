using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using Quartz.Persistence.Nhibernate;
using Quartz.Persistence.Nhibernate.Mappings;

namespace Quartz.Core.Domain.Test
{
    public class NhibernateSessionFactoryTest : INhibernateSessionFactory
    {
        public static NHibernate.Cfg.Configuration configuration;

        public ISessionFactory SessionFactory()
        {
            return Fluently.Configure()
                    .Database(SQLiteConfiguration.Standard.InMemory().ShowSql())
                    .Mappings(m => m.FluentMappings.AddFromAssemblyOf<ReservoirMap>())
                    .ExposeConfiguration(cfg => configuration = cfg)
                    .BuildSessionFactory();
        }
    }
}
