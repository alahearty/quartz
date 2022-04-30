using MediatR;

namespace Quartz.Application.Reservoirs.QueryInteractors
{
    public class GetReservoirByNameRequest: IRequest<ReservoirDto>
    {
        public string Name { get; set; }
    }
}
