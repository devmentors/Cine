using System;
using Cine.Shared.Exceptions;

namespace Cine.Modules.Schedules.Core.Exceptions
{
    public class EmptyShowException : DomainException
    {
        public override string ErrorCode => "empty_show";

        public EmptyShowException(Guid scheduleId)
            : base($"Show for schedule {scheduleId} is empty")
        {
        }
    }
}
