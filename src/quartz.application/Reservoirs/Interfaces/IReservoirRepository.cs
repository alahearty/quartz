using Quartz.Application.Interfaces;
using Quartz.Domain.Reservoirs;

namespace Quartz.Application.Reservoirs.Interfaces
{
    public interface IReservoirRepository : IRepository<Reservoir>
    {
        IQuartzTransaction Transaction { get; }
        Reservoir GetByName(string name);
    }
}
