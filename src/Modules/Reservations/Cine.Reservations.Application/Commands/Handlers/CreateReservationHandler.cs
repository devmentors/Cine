using System.Linq;
using System.Threading.Tasks;
using Cine.Reservations.Application.Exceptions;
using Cine.Reservations.Core.Aggregates;
using Cine.Reservations.Core.Factories;
using Cine.Reservations.Core.Repositories;
using Cine.Reservations.Core.ValueObjects;
using Cine.Shared.Events;
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
            var seats = command.Seats.Select(s => new Seat(s.Row, s.Number, s.Price, s.IsVip));
            var reservee = command.Reservee is null ? null : new Reservee(c)

            var reservation = await _factory.CreateAsync(command.Id, command.CinemaId, command.MovieId, command.HallId,
                command.CustomerId, command.IsPaymentUponArrival, )

            await _repository.AddAsync(reservation);
            await _processor.ProcessAsync(reservation.DomainEvents);
        }
    }
}
