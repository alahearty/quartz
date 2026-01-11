using MediatR;
using Quartz.Application.Reservoirs.Interfaces;
using System.Threading;
using System.Threading.Tasks;

namespace Quartz.Application.Reservoirs.CommandInteractors
{
    public class DeleteReservoirInteractor : IRequestHandler<DeleteReservoirRequest>
    {
        private readonly IReservoirRepository _reservoirRepository;

        public DeleteReservoirInteractor(IReservoirRepository reservoirRepository)
        {
            _reservoirRepository = reservoirRepository;
        }

        public async Task Handle(DeleteReservoirRequest request, CancellationToken cancellationToken)
        {
            var reservoir = _reservoirRepository.GetById(request.Id);
            if(reservoir  == null)
            {
                throw new InvalidQuartzOperationException($"Reservoir with id: '{request.Id}' does not exist!");
            }

            _reservoirRepository.Delete(reservoir);
            _reservoirRepository.Transaction.Commit();

            await Task.CompletedTask;
        }
    }
}
