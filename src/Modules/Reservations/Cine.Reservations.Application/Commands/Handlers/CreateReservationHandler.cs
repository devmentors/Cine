using System.Threading.Tasks;
using Cine.Reservations.Application.Exceptions;
using Cine.Reservations.Core.Aggregates;
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

        public async Task HandleAsync(CreateReservation command)
        {
            // var reservation = Reservation.Create(command.Id, command.CinemaId, command.MovieId, command.HallId,
            //     command.Price, command.IsPaymentUponArrival, command.Row, command.Number, command.IsVip);

            // var alreadyExists = await _repository.ExistsAsync(reservation.Key);
            //
            // if (alreadyExists)
            // {
            //     throw new ReservationAlreadyExistsException(command.MovieId, command.Row, command.Number);
            // }
            //
            // await _repository.AddAsync(reservation);
            // await _processor.ProcessAsync(reservation.DomainEvents);
        }
    }
}
