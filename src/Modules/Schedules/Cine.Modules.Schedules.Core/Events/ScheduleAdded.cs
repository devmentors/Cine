using Cine.Modules.Schedules.Core.Aggregates;
using Cine.Shared.BuildingBlocks;

namespace Cine.Modules.Schedules.Core.Events
{
    public class ScheduleAdded : IDomainEvent
    {
        public Schedule Schedule { get; }

        public ScheduleAdded(Schedule schedule)
        {
            Schedule = schedule;
        }
    }
}
