using System;
using System.Linq;

namespace Cine.Shared.Exceptions.Mappers
{
    internal sealed class DefaultExceptionToResponseMapper : IExceptionToResponseMapper
    {
        public (int httpStatusCode, string[] errorCodes)? Map(Exception exception)
            => exception switch
            {
                EmptyAggregateIdException ex => (400, new [] { ex.ErrorCode }),
                ValidationException ex => (400, ex.Errors.ToArray()),
                NotFoundException ex => (404, null),
                _ => null
            };
    }
}
