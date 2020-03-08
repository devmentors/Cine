using System;
using Cine.Shared.Exceptions;

namespace Cine.Modules.Movies.Api.Exceptions
{
    public class MovieAlreadyExistsException : AppException
    {
        public override string ErrorCode => "movie_already_exists";

        public MovieAlreadyExistsException(Guid id) : base($"Movie with id {id} was not found.")
        {
        }
    }
}
