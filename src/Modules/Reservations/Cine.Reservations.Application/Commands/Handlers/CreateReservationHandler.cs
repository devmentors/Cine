using System.Threading.Tasks;
using Cine.Reservations.Application.Exceptions;
using Cine.Reservations.Core.Factories;
using Cine.Reservations.Core.Repositories;
using Cine.Shared.Events;
using Cine.Shared.Kernel.ValueObjects;
using Convey.CQRS.Commands;

namespace Cine.Reservations.Application.Commands.Handlers
{
    public sealed class CreateReservationHandler : ICommandHandler<CreateReservation>
    {
        private readonly IReservationsFactory _factory;
        private readonly IReservationsRepository _repository;
        private readonly IEventProcessor _processor;

        public CreateReservationHandler(IReservationsFactory factory, IReservationsRepository repository,
            IEventProcessor processor)
        {
            _repository = repository;
            _processor = processor;
            _factory = factory;
        }

        public async Task HandleAsync(CreateReservation command)
        {
            if (await _repository.ExistsAsync(command.Id))
            {
                throw new ReservationAlreadyExistsException(command.Id);
            }

            var seats = command.Seats.AsValueObjects();
            var reservee = command.Reservee.AsValueObject();

            var reservation = await _factory.CreateAsync(command.Id, command.CinemaId, command.MovieId, command.HallId,
                command.CustomerId, command.DateTime, command.IsPaymentUponArrival, seats, reservee);

            await _repository.AddAsync(reservation);
            await _processor.ProcessAsync(reservation.DomainEvents);
        }
    }
}
