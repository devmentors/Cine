using System;
using Cine.Shared.Exceptions;

namespace Cine.Modules.Cinemas.Api.Exceptions
{
    public class CinemaAlreadyExistsException : AppException
    {
        public override string ErrorCode => "cinema_already_exists";

        public CinemaAlreadyExistsException(Guid id) : base($"Cinema with id {id} already exists.")
        {
        }
    }
}
