using Cine.Modules.Schedules.Core;
using Cine.Shared.Exceptions;

namespace Cine.Modules.Schedules.Application.Exceptions
{
    public class ScheduleSchemaAlreadyExistsException : AppException
    {
        public override string ErrorCode => "schedule_schema_already_exists";

        public ScheduleSchemaAlreadyExistsException(CinemaId cinemaId)
            : base($"Schedule schema for cinema with id {cinemaId} already exists")
        {
        }
    }
}
