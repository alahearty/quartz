using MediatR;
using Quartz.Application.Reservoirs.Interfaces;
using System.Threading;
using System.Threading.Tasks;

namespace Quartz.Application.Reservoirs.QueryInteractors
{
    public class GetReservoirByNameInteractor : IRequestHandler<GetReservoirByNameRequest, ReservoirDto>
    {
        private readonly IReservoirQueries _reservoirQueries;

        public GetReservoirByNameInteractor(IReservoirQueries reservoirQueries)
        {
            _reservoirQueries = reservoirQueries;
        }

        public async Task<ReservoirDto> Handle(GetReservoirByNameRequest request, CancellationToken cancellationToken)
        {
            var reservoir = _reservoirQueries.GetReservoirByName(request.Name);

            return await Task.FromResult(reservoir);
        }
    }
}
