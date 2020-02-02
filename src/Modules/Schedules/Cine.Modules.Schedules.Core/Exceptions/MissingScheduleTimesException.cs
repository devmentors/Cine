using Cine.Shared.Exceptions;

namespace Cine.Modules.Schedules.Core.Exceptions
{
    public class MissingScheduleTimesException : DomainException
    {
        public MissingScheduleTimesException(CinemaId cinemaId, int ageRestriction)
            : base($"Schedule schema for cinema {cinemaId} does not define hours for age {ageRestriction}")
        {
        }
    }
}
