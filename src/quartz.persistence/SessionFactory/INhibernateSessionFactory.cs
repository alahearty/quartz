using NHibernate;

namespace Quartz.Persistence.Nhibernate
{
    public interface INhibernateSessionFactory
    {
        ISessionFactory SessionFactory();
    }
}
