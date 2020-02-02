using System.Collections.Generic;
using System.Linq;
using Cine.Shared.Exceptions;

namespace Cine.Modules.Schedules.Core.Exceptions
{
    public class DuplicatedScheduleTimeException : DomainException
    {
        public DuplicatedScheduleTimeException(IEnumerable<int> ages)
            : base($"Schedule time has been duplicated for age restrictions: {string.Join(',', ages)}")
        {
        }
    }
}
