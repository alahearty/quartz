using NHibernate;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Quartz.Persistence.Nhibernate
{
    public class NHibernateTransaction : INhibernateTransaction
    {
        private ISession _session;
        private readonly INhibernateSessionFactory nhibernateSessionFactory;

        public NHibernateTransaction(INhibernateSessionFactory nhibernateSessionFactory)
        {
            this.nhibernateSessionFactory = nhibernateSessionFactory;
            _session = this.nhibernateSessionFactory.SessionFactory().OpenSession();
        }

        public ISession Session
        {
            get
            {
                if (_session == null)
                    _session = nhibernateSessionFactory.SessionFactory().OpenSession();
                return _session;
            }
        }

        public void Commit()
        {
            ITransaction transaction = null;
            try
            {
                transaction = _session.BeginTransaction();
                transaction.Commit();
            }
            catch (Exception)
            {
                if (transaction != null)
                {
                    transaction.Rollback();
                }

                throw;
            }
            finally
            {
                transaction.Dispose();
                _session.Dispose();
            }
        }

        public async Task CommitAsync(CancellationToken cancellationToken)
        {
            ITransaction transaction = null;
            try
            {
                transaction = Session.BeginTransaction();
                await transaction.CommitAsync(cancellationToken);
            }
            catch (Exception)
            {
                if (transaction != null)
                {
                    transaction.Rollback();
                }

                throw;
            }
            finally
            {
                _session.Dispose();
                _session = null;
            }
        }
    }
}
