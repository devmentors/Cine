using System.Collections.Generic;
using Cine.Shared.BuildingBlocks;

namespace Cine.Shared.Events
{
    public interface IEventMapper
    {
        IEvent Map(IDomainEvent domainEvent);
        IEnumerable<IEvent> MapAll(IEnumerable<IDomainEvent> domainEvents);
    }
}
