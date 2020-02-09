using System;

namespace Cine.Shared.Exceptions.Mappers
{
    internal sealed class DefaultExceptionToResponseMapper : IExceptionToResponseMapper
    {
        public (int httpStatusCode, string[] errorCodes)? Map(Exception exception)
            => exception switch
            {
                EmptyAggregateIdException ex => (400, new [] { "empty_aggregate_id" }),
                _ => null
            };
    }
}
