using System.Threading.Tasks;
using Cine.Reservations.Core.Repositories;
using Cine.Shared.Events;
using Convey.CQRS.Commands;

namespace Cine.Reservations.Application.Commands.Handlers
{
    public sealed class CreateReservationHandler : ICommandHandler<CreateReservation>
    {
        private readonly IReservationsRepository _repository;
        private readonly IEventProcessor _processor;

        public CreateReservationHandler(IReservationsRepository repository, IEventProcessor processor)
        {
            _repository = repository;
            _processor = processor;
        }

        public Task HandleAsync(CreateReservation command)
        {
            throw new System.NotImplementedException();
        }
    }
}
