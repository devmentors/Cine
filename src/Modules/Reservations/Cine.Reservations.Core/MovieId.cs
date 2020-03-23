using System;
using Cine.Shared.BuildingBlocks;

namespace Cine.Reservations.Core
{
    public sealed class MovieId : TypedId
    {
        public static MovieId Empty => new MovieId(Guid.Empty);

        public MovieId(Guid value) : base(value)
        {
        }

        public static implicit operator MovieId(Guid movieId)
            => new MovieId(movieId);
    }
}
