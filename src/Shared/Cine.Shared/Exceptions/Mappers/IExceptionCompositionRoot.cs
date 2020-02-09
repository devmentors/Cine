using System;

namespace Cine.Shared.Exceptions.Mappers
{
    public interface IExceptionCompositionRoot
    {
        (int httpStatusCode, string[] errorCodes)? Map(Exception exception);
    }
}
