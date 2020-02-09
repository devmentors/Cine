using System;

namespace Cine.Shared.Exceptions.Mappers
{
    public interface IExceptionToResponseMapper
    {
        (int httpStatusCode, string errorCode)? Map(Exception exception);
    }
}
