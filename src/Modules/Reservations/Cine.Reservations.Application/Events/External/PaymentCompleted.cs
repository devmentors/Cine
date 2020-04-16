using System;
using Cine.Shared.Events;

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
