using Cine.Shared.BuildingBlocks;

namespace Cine.Modules.Schedules.Core.Entities
{
    public class Hall : IEntity
    {
        public EntityId Id { get; private set; }

        public Hall(EntityId id)
        {
            Id = id;
        }
    }
}
