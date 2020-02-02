using System.Collections.Generic;
using System.Linq;
using Cine.Shared.Exceptions;

namespace Cine.Modules.Schedules.Core.Exceptions
{
    public class DuplicatedScheduleHourException : DomainException
    {
        public DuplicatedScheduleHourException(IEnumerable<int> ages)
            : base($"Schedule hour has been duplicated for age restrictions: {string.Join(',', ages)}")
        {
        }
    }
}
