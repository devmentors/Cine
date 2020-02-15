using System;
using Cine.Shared.Exceptions.Middlewares;

namespace Cine.Shared.Exceptions.Mappers
{
    public interface IExceptionCompositionRoot
    {
        ExceptionResponse Map(Exception exception);
    }
}
