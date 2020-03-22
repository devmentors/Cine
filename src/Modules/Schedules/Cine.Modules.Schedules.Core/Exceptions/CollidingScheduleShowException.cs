using System;
using Cine.Modules.Schedules.Core.ValueObjects;
using Cine.Shared.Exceptions;

namespace Cine.Modules.Schedules.Core.Exceptions
{
    public class CollidingScheduleShowException : DomainException
    {
        public override string ErrorCode => "colliding_schedule_show";

        public CollidingScheduleShowException(Guid scheduleId, DateTime date, Time time)
            : base($"Schedule {scheduleId} has already has show at {date.Date} {time.Hour}:{time.Minute}")
        {
        }
    }
}
