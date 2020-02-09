using System;

namespace Cine.Shared.Exceptions.Mappers
{
    public interface IExceptionToResponseMapper
    {
        (int httpStatusCode, string[] errorCodes)? Map(Exception exception);
    }
}
