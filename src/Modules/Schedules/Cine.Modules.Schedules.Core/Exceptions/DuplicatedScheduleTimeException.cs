using System.Collections.Generic;
using Cine.Shared.Exceptions;

namespace Cine.Modules.Schedules.Core.Exceptions
{
    public class DuplicatedScheduleTimeException : DomainException
    {
        public override string ErrorCode => "duplicated_schedule_time";

        public DuplicatedScheduleTimeException(IEnumerable<int> ages)
            : base($"Schedule time has been duplicated for age restrictions: {string.Join(',', ages)}")
        {
        }
    }
}
