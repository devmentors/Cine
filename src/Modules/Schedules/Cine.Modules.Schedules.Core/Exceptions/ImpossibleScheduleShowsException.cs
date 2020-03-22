using System;
using Cine.Modules.Schedules.Core.ValueObjects;
using Cine.Shared.Exceptions;

namespace Cine.Modules.Schedules.Core.Exceptions
{
    public class ImpossibleScheduleShowsException : DomainException
    {
        public override string ErrorCode => "impossible_schedule_shows";

        public ImpossibleScheduleShowsException(MovieId movieId, DateTime date)
            : base($"Schedule show for movie {movieId} at {date} was not possible")
        {
        }
    }
}
