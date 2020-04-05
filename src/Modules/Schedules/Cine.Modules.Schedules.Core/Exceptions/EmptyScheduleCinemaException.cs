using Cine.Shared.BuildingBlocks;
using Cine.Shared.Exceptions;

namespace Cine.Modules.Schedules.Core.Exceptions
{
    public class EmptyScheduleCinemaException : DomainException
    {
        public override string ErrorCode => "empty_schedule_cinema";

        public EmptyScheduleCinemaException(EntityId scheduleId)
            : base($"Empty cinema defined for schedule with id {scheduleId}")
        {
        }
    }
}
