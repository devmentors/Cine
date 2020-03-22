using System;
using Convey.CQRS.Events;

namespace Cine.Modules.Schedules.Application.Events
{
    public class ScheduleCreated : IEvent
    {
        public Guid ScheduleId { get; }

        public ScheduleCreated(Guid scheduleId)
        {
            ScheduleId = scheduleId;
        }
    }
}
