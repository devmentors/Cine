using System;
using Cine.Shared.Exceptions;

namespace Cine.Modules.Schedules.Core.Exceptions
{
    public class EmptyScheduleSchemaCinemaException : DomainException
    {
        public override string ErrorCode => "empty_schedule_schema_cinema";

        public EmptyScheduleSchemaCinemaException(Guid schemaId)
            :base($"Empty cinema defined for schedule schema with id {schemaId}")
        {
        }
    }
}
