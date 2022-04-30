using NHibernate;
using NHibernate.Tool.hbm2ddl;
using Quartz.Persistence.Nhibernate;
using System.Threading;
using System.Threading.Tasks;

namespace Quartz.Core.Domain.Test
{
    public class NhibernateTransactionTest : INhibernateTransaction
    {
        private readonly ISession _session;
        private readonly INhibernateSessionFactory sessionFactory;

        public NhibernateTransactionTest(INhibernateSessionFactory sessionFactory)
        {
            this.sessionFactory = sessionFactory;
            _session = OpenSession();
        }

        public ISession Session => _session;

        public void Commit()
        {
            using(var trans = Session.BeginTransaction())
            {
                trans.Commit();
            }
        }

        public async Task CommitAsync(CancellationToken cancel)
        {
            using (var trans = Session.BeginTransaction())
            {
                await trans.CommitAsync(cancel);
            }
        }

        private ISession OpenSession()
        {
            var session = sessionFactory.SessionFactory().OpenSession();
            var export = new SchemaExport(NhibernateSessionFactoryTest.configuration);
            export.Execute(true, true, false, session.Connection, null);

            return session;
        }
    }
}
