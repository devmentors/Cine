using System.Collections.Generic;
using Cine.Shared.BuildingBlocks;
using Convey.CQRS.Events;

namespace Cine.Shared.Events
{
    public interface IEventMapperCompositionRoot
    {
        IEvent Map(IDomainEvent domainEvent);
        IEnumerable<IEvent> MapAll(IEnumerable<IDomainEvent> domainEvents);
    }
}
