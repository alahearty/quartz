using MediatR;

namespace Quartz.Application.Reservoirs.QueryInteractors
{
    public class GetReservoirByIdRequest: IRequest<ReservoirDto>
    {
        public int Id { get; set; }
    }
}
