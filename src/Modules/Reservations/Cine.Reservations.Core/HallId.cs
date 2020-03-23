using System;
using Cine.Shared.BuildingBlocks;

namespace Cine.Reservations.Core
{
    public sealed class HallId : TypedId
    {
        public static HallId Empty => new HallId(Guid.Empty);

        public HallId(Guid value) : base(value)
        {
        }

        public static implicit operator HallId(Guid hallId)
            => new HallId(hallId);
    }
}
