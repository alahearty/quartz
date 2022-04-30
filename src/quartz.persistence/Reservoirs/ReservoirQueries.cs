using NHibernate;
using Quartz.Application.Interfaces;
using Quartz.Application.Reservoirs.Interfaces;
using Quartz.Application.Reservoirs.QueryInteractors;
using Quartz.Domain.Reservoirs;
using System.Collections.Generic;
using System.Linq;

namespace Quartz.Persistence.Nhibernate.Reservoirs
{
    public class ReservoirQueries : IReservoirQueries
    {
        private readonly INhibernateTransaction nhibernateTransaction;

        public ReservoirQueries(INhibernateTransaction nhibernateTransaction)
        {
            this.nhibernateTransaction = nhibernateTransaction;
        }

        public IQuartzTransaction Transaction => nhibernateTransaction;

        public IList<ReservoirListDto> GetAllReservoirs()
        {
            var reservoirLists = nhibernateTransaction.Session.Query<Reservoir>().Select(reservoir => new ReservoirListDto
            {
                Id = reservoir.Id,
                Name = reservoir.Name
            }).ToList();

            return reservoirLists;
        }

        public ReservoirDto GetReservoirById(int id)
        {
            var reservoir = nhibernateTransaction.Session.Get<Reservoir>(id);

            return ReservoirDto.From(reservoir);
        }

        public ReservoirDto GetReservoirByName(string name)
        {
            var reservoir = nhibernateTransaction.Session.QueryOver<Reservoir>()
            .WhereRestrictionOn(x => x.Name).IsInsensitiveLike(name)
            .SingleOrDefault();

            return ReservoirDto.From(reservoir);
        }
    }
}
