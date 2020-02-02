using Cine.Shared.Exceptions;

namespace Cine.Modules.Schedules.Core.Exceptions
{
    public class ScheduleSchemaNotFoundException : DomainException
    {
        public ScheduleSchemaNotFoundException(CinemaId cinemaId)
            : base($"Schedule schema for cinema {cinemaId} was not found")
        {
        }
    }
}
