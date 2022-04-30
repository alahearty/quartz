using NHibernate;
using Quartz.Application.Interfaces;

namespace Quartz.Persistence.Nhibernate
{
    public interface INhibernateTransaction : IQuartzTransaction
    {
        ISession Session { get; }
    }
}
