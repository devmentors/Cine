using System;
using Cine.Shared.BuildingBlocks;

namespace Cine.Reservations.Core
{
    public class CustomerId : TypedId
    {
        public static CustomerId Empty => new CustomerId(Guid.Empty);

        public CustomerId(Guid value) : base(value)
        {
        }

        public static implicit operator CustomerId(Guid hallId)
            => new CustomerId(hallId);
    }
}
