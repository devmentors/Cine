using System;
using Cine.Shared.Exceptions.Middlewares;

namespace Cine.Shared.Exceptions.Mappers
{
    public interface IExceptionToResponseMapper
    {
        ExceptionResponse Map(Exception exception);
    }
}
