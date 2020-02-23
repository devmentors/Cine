using Cine.Modules.Schedules.Core;
using Cine.Shared.Exceptions;

namespace Cine.Modules.Schedules.Application.Exceptions
{
    public class ScheduleAlreadyExistsException : AppException
    {
        public override string ErrorCode => "schedule_already_exists";

        public ScheduleAlreadyExistsException(CinemaId cinemaId, MovieId movieId)
            : base($"Schedule for cinema {cinemaId} and movie {movieId} already exists")
        {
        }
    }
}
