using Cine.Modules.Schedules.Core.Aggregates;
using Cine.Modules.Schedules.Core.Types;
using Cine.Shared.BuildingBlocks;

namespace Cine.Modules.Schedules.Core.Events
{
    public class ScheduleSchemaTimesChanged : IDomainEvent
    {
        public ScheduleSchema Schema { get; }
        public ScheduleSchemaTimes Times { get; }

        public ScheduleSchemaTimesChanged(ScheduleSchema schema, ScheduleSchemaTimes times)
        {
            Schema = schema;
            Times = times;
        }
    }
}
