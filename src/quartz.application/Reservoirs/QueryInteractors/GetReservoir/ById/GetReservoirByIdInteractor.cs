using MediatR;
using Quartz.Application.Reservoirs.Interfaces;
using System.Threading;
using System.Threading.Tasks;

namespace Quartz.Application.Reservoirs.QueryInteractors
{
    public class GetReservoirByIdInteractor : IRequestHandler<GetReservoirByIdRequest, ReservoirDto>
    {
        private readonly IReservoirQueries _reservoirQueries;

        public GetReservoirByIdInteractor(IReservoirQueries reservoirQueries)
        {
            _reservoirQueries = reservoirQueries;
        }

        public async Task<ReservoirDto> Handle(GetReservoirByIdRequest request, CancellationToken cancellationToken)
        {
            var reservoir = _reservoirQueries.GetReservoirById(request.Id);

            return await Task.FromResult(reservoir);
        }
    }
}
