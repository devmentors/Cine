using System;
using Cine.Modules.Schedules.Core.ValueObjects;
using Cine.Shared.Exceptions;

namespace Cine.Modules.Schedules.Core.Exceptions
{
    public class CollidingScheduleReservationException : DomainException
    {
        public override string ErrorCode => "colliding_schedule_reservation";

        public CollidingScheduleReservationException(Guid scheduleId, DateTime date, Time time)
            : base($"Schedule {scheduleId} has already reserved at {date.Date} {time.Hour}:{time.Minute}")
        {
        }
    }
}
