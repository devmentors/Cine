using System;
using Cine.Shared.BuildingBlocks;

namespace Cine.Modules.Schedules.Core
{
    public sealed class MovieId : TypedId
    {
        public static MovieId Empty => new MovieId(Guid.Empty);

        public MovieId(Guid value) : base(value)
        {
        }

        public static implicit operator MovieId(Guid agreementId)
            => new MovieId(agreementId);
    }
}
