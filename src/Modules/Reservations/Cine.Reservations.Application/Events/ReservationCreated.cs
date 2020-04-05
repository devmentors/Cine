using System;
using Convey.CQRS.Events;

namespace Cine.Reservations.Application.Events
{
    public class ReservationCreated : IEvent
    {
        public Guid Id { get; }

        public ReservationCreated(Guid id)
        {
            Id = id;
        }
    }
}
