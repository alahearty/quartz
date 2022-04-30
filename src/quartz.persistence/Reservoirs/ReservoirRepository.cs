using NHibernate;
using Quartz.Application.Interfaces;
using Quartz.Application.Reservoirs.Interfaces;
using Quartz.Domain.Reservoirs;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Quartz.Persistence.Nhibernate.Reservoirs
{
    public class ReservoirRepository : IReservoirRepository
    {
        private readonly INhibernateTransaction nhibernateTransaction;

        public ReservoirRepository(INhibernateTransaction nhibernateTransaction)
        {
            this.nhibernateTransaction = nhibernateTransaction;
        }

        public IQuartzTransaction Transaction => nhibernateTransaction;

        public void Save(Reservoir entity)
        {
            nhibernateTransaction.Session.Save(entity);
        }

        public async Task SaveAsync(Reservoir entity)
        {
            await nhibernateTransaction.Session.SaveAsync(entity);
        }

        public void Delete(Reservoir entity)
        {
            nhibernateTransaction.Session.Delete(entity);
        }

        public async Task DeleteAsync(Reservoir entity)
        {
            await nhibernateTransaction.Session.DeleteAsync(entity);
        }

        public IList<Reservoir> GetAll()
        {
            return nhibernateTransaction.Session.Query<Reservoir>().ToList();
        }

        public void Update(Reservoir entity)
        {
            nhibernateTransaction.Session.Update(entity);
        }

        public async Task UpdateAsync(Reservoir entity)
        {
            await nhibernateTransaction.Session.UpdateAsync(entity);
        }

        public Reservoir GetByName(string name)
        {
            return nhibernateTransaction.Session.QueryOver<Reservoir>()
            .WhereRestrictionOn(x => x.Name).IsInsensitiveLike(name)
            .SingleOrDefault();
        }

        public Reservoir GetById(int id)
        {
            return nhibernateTransaction.Session.Get<Reservoir>(id);
        }
    }
}
