using Cine.Shared.BuildingBlocks;
using Cine.Shared.Exceptions;

namespace Cine.Modules.Schedules.Core.Exceptions
{
    public class EmptyScheduleMovieException : DomainException
    {
        public override string ErrorCode => "empty_schedule_cinema";

        public EmptyScheduleMovieException(EntityId scheduleId)
            : base($"Empty movie defined for schedule with id {scheduleId}")
        {
        }
    }
}
