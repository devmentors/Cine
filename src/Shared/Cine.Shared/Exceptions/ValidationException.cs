using System.Collections.Generic;

namespace Cine.Shared.Exceptions
{
    public sealed class ValidationException : DomainException
    {
        public IEnumerable<string> Errors { get; }

        public ValidationException(IEnumerable<string> errors)
            => Errors = errors;
    }
}
