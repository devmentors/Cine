using System;
using Cine.Shared.Events;

namespace Cine.Modules.Schedules.Application.Events
{
    public class ScheduleSchemaCreated : IEvent
    {
        public Guid SchemaId { get; }

        public ScheduleSchemaCreated(Guid schemaId)
        {
            SchemaId = schemaId;
        }
    }
}
