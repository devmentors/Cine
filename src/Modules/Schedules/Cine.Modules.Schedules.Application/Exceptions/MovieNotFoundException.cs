using System;
using Cine.Modules.Schedules.Core;

namespace Cine.Modules.Schedules.Application.Exceptions
{
    public class MovieNotFoundException : Exception
    {
        public MovieNotFoundException(MovieId movieId) : base($"Movie with id {movieId} was not found")
        {

        }
    }
}
