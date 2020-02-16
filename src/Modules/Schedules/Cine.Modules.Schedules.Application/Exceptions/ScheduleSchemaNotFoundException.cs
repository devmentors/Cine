using System;
using Cine.Shared.Exceptions;

namespace Cine.Modules.Schedules.Application.Exceptions
{
    public class ScheduleSchemaNotFoundException : AppException
    {
        public override string ErrorCode => "schedule_schema_not_found";

        public ScheduleSchemaNotFoundException(Guid scheduleSchemaId)
            : base($"Schedule schema with id {scheduleSchemaId} was not found")
        {
        }

    }
}
