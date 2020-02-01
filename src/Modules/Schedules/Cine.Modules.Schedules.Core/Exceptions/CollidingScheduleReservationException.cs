using System;
using Cine.Modules.Schedules.Core.ValueObjects;
using Cine.Shared.Exceptions;

namespace Cine.Modules.Schedules.Core.Exceptions
{
    public class CollidingScheduleReservationException : DomainException
    {
        public CollidingScheduleReservationException(Guid scheduleId, DateTime date, ScheduleTime time)
            : base($"Schedule {scheduleId} has already reserved at {date.Date} {time}")
        {
        }
    }
}
