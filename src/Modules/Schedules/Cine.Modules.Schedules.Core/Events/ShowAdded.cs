using Cine.Modules.Schedules.Core.Aggregates;
using Cine.Modules.Schedules.Core.ValueObjects;
using Cine.Shared.BuildingBlocks;

namespace Cine.Modules.Schedules.Core.Events
{
    public class ShowAdded : IDomainEvent
    {
        public Schedule Schedule { get; }
        public Show Show { get; }

        public ShowAdded(Schedule schedule, Show show)
        {
            Schedule = schedule;
            Show = show;
        }
    }
}
