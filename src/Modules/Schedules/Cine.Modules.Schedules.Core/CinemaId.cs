using System;
using Cine.Shared.BuildingBlocks;

namespace Cine.Modules.Schedules.Core
{
    public class CinemaId : TypedId
    {
        public static CinemaId Empty => new CinemaId(Guid.Empty);

        public CinemaId(Guid value) : base(value)
        {
        }

        public static implicit operator CinemaId(Guid cinemaId)
            => new CinemaId(cinemaId);
    }
}
