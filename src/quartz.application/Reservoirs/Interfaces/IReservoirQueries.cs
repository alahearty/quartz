using Quartz.Application.Reservoirs.QueryInteractors;
using System.Collections.Generic;

namespace Quartz.Application.Reservoirs.Interfaces
{
    public interface IReservoirQueries
    {
        IList<ReservoirListDto> GetAllReservoirs();
        ReservoirDto GetReservoirById(int id);
        ReservoirDto GetReservoirByName(string name);
    }
}
