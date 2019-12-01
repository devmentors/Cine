using System;

namespace Cinema.Shared.BuildingBlocks
{
    public class EntityId : TypedId
    {
        public EntityId(Guid value) : base(value)
        {
        }

        public static implicit operator EntityId(Guid id)
            => new EntityId(id);
    }
}
