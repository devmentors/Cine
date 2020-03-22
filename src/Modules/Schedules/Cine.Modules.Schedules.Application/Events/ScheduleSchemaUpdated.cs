using System;
using Convey.CQRS.Events;

namespace Cine.Modules.Schedules.Application.Events
{
    public class ScheduleSchemaUpdated : IEvent
    {
        public Guid SchemaId { get; }

        public ScheduleSchemaUpdated(Guid schemaId)
        {
            SchemaId = schemaId;
        }
    }
}
