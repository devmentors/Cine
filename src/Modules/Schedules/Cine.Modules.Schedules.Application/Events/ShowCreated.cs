using System;
using Convey.CQRS.Events;

namespace Cine.Modules.Schedules.Application.Events
{
    public class ShowCreated : IEvent
    {
        public Guid ScheduleId { get; }
        public Guid HallId { get; }
        public DateTime DateTime { get; }

        public ShowCreated(Guid scheduleId, Guid hallId, DateTime dateTime)
        {
            ScheduleId = scheduleId;
            HallId = hallId;
            DateTime = dateTime;
        }
    }
}
