using System.Threading.Tasks;
using Cine.Reservations.Application.Exceptions;
using Cine.Reservations.Core.Repositories;
using Cine.Reservations.Core.Types;
using Convey.CQRS.Events;

namespace Cine.Reservations.Application.Events.External.Handlers
{
    public sealed class PaymentCompletedHandler : IEventHandler<PaymentCompleted>
    {
        private readonly IReservationsRepository _repository;

        public PaymentCompletedHandler(IReservationsRepository repository)
            => _repository = repository;

        public async Task HandleAsync(PaymentCompleted @event)
        {
            var reservation = await _repository.GetAsync(@event.ReservationId);

            if (reservation is null)
            {
                throw new ReservationNotFoundException(@event.ReservationId);
            }

            reservation.ChangeStatus(ReservationStatus.Paid);
            await _repository.UpdateAsync(reservation);
        }
    }
}
