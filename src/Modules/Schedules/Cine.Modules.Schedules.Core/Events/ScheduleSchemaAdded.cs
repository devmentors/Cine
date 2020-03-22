using Cine.Modules.Schedules.Core.Aggregates;
using Cine.Shared.BuildingBlocks;

namespace Cine.Modules.Schedules.Core.Events
{
    public class ScheduleSchemaAdded : IDomainEvent
    {
        public ScheduleSchema Schema { get; }

        public ScheduleSchemaAdded(ScheduleSchema schema)
        {
            Schema = schema;
        }
    }
}
