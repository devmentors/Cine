using System;
using Cine.Shared.Exceptions;

namespace Cine.Modules.Movies.Api.Exceptions
{
    public class MovieNotFoundException : AppException
    {
        public override string ErrorCode => "movie_not_found";

        public MovieNotFoundException(Guid movieId) : base($"Movie with id {movieId} was not found")
        {
        }
    }
}
