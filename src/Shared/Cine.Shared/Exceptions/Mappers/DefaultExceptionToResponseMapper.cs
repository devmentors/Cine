using System;
using System.Net;
using Cine.Shared.Exceptions.Middlewares;

namespace Cine.Shared.Exceptions.Mappers
{
    internal sealed class DefaultExceptionToResponseMapper : IExceptionToResponseMapper
    {
        public ExceptionResponse Map(Exception exception)
            => exception switch
            {
                EmptyAggregateIdException ex => new ExceptionResponse { HttpStatus = HttpStatusCode.BadGateway,
                    Code = ex.ErrorCode, Message = ex.Message},
                ValidationException ex => new ExceptionResponse { HttpStatus = HttpStatusCode.BadGateway,
                    Code = "validation_failed", Message = string.Join(Environment.NewLine, ex.Errors)},
                NotFoundException ex => new ExceptionResponse { HttpStatus = HttpStatusCode.NotFound,
                    Code = "resource_not_found", Message = "Requested resource was not found"},
                _ => new ExceptionResponse { HttpStatus = HttpStatusCode.BadRequest, Code = "error",
                    Message = "There was an error"}
            };
    }
}
