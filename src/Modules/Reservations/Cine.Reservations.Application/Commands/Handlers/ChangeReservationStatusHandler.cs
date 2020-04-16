using System;
using System.Threading.Tasks;
using Cine.Reservations.Application.Exceptions;
using Cine.Reservations.Core.Repositories;
using Cine.Reservations.Core.Types;
using Cine.Shared.Commands;
using Cine.Shared.Events;

namespace Cine.Reservations.Application.Commands.Handlers
{
    public sealed class ChangeReservationStatusHandler : ICommandHandler<CompleteReservation>, ICommandHandler<CancelReservation>
    {
        private readonly IReservationsRepository _repository;
        private readonly IEventProcessor _processor;

        public ChangeReservationStatusHandler(IReservationsRepository repository, IEventProcessor processor)
        {
            _repository = repository;
            _processor = processor;
        }

        public Task HandleAsync(CompleteReservation command)
            => ChangeReservationStatus(command.Id, ReservationStatus.Completed);

        public Task HandleAsync(CancelReservation command)
            => ChangeReservationStatus(command.Id, ReservationStatus.Canceled);

        private async Task ChangeReservationStatus(Guid id, ReservationStatus status)
        {
            var reservation = await _repository.GetAsync(id);

            if (reservation is null)
            {
                throw new ReservationNotFoundException(id);
            }

            reservation.ChangeStatus(status);
            await _repository.UpdateAsync(reservation);
            await _processor.ProcessAsync(reservation.DomainEvents);
        }
    }
}
