using System;
using Convey.CQRS.Events;

namespace Cine.Reservations.Application.Events
{
    public class ReservationStatusChanged : IEvent
    {
        public Guid Id { get; }
        public string CurrentStatus { get; }

        public ReservationStatusChanged(Guid id, string currentStatus)
        {
            Id = id;
            CurrentStatus = currentStatus;
        }
    }
}
