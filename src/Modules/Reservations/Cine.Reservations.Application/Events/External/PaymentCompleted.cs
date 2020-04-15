using System;
using Convey.CQRS.Events;

namespace Cine.Reservations.Application.Events.External
{
    public class PaymentCompleted : IEvent
    {
        public Guid ReservationId { get; }

        public PaymentCompleted(Guid reservationId)
        {
            ReservationId = reservationId;
        }
    }
}
