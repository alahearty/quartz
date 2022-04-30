using MediatR;

namespace Quartz.Application.Reservoirs.CommandInteractors
{
    public class DeleteReservoirRequest : IRequest
    {
        public int Id { get; set; }
    }
}
