using System;
using Cine.Shared.Exceptions;

namespace Cine.Modules.Schedules.Core.Exceptions
{
    public class EmptyReservationException : DomainException
    {
        public EmptyReservationException(Guid scheduleId)
            : base($"Reservation for schedule {scheduleId} is empty")
        {
        }
    }
}
