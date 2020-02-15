using System;
using Cine.Modules.Schedules.Core.ValueObjects;
using Cine.Shared.Exceptions;

namespace Cine.Modules.Schedules.Core.Exceptions
{
    public class ImpossibleScheduleReservationException : DomainException
    {
        public override string ErrorCode => "impossible_schedule_reservation";

        public ImpossibleScheduleReservationException(MovieId movieId, DateTime date)
            : base($"Schedule reservation for movie {movieId} at {date} was not possible")
        {
        }
    }
}
