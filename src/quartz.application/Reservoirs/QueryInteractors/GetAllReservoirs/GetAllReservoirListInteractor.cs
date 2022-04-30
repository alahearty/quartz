using MediatR;
using Quartz.Application.Reservoirs.Interfaces;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Quartz.Application.Reservoirs.QueryInteractors
{
    public class GetAllReservoirListInteractor : IRequestHandler<GetAllReservoirListRequest, IEnumerable<ReservoirListDto>>
    {
        private readonly IReservoirQueries _reservoirQueries;

        public GetAllReservoirListInteractor(IReservoirQueries reservoirQueries)
        {
            _reservoirQueries = reservoirQueries;
        }

        public async Task<IEnumerable<ReservoirListDto>> Handle(GetAllReservoirListRequest request, CancellationToken cancellationToken)
        {
            var reservoirs = _reservoirQueries.GetAllReservoirs();

            return await Task.FromResult(reservoirs);
        }
    }
}
