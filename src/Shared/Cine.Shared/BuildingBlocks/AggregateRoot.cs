using System.Collections.Generic;
using System.Linq;
using Cine.Shared.Exceptions;

namespace Cine.Shared.BuildingBlocks
{
    public abstract class AggregateRoot : IEntity
    {
        public EntityId Id { get; protected set; }
        public int Version { get; protected set; }

        protected AggregateRoot(EntityId id)
        {
            if (id is null || id.IsEmpty())
            {
                throw new EmptyAggregateIdException();
            }

            Id = id;
        }

        private readonly List<IDomainEvent> _domainEvents = new List<IDomainEvent>();
        public IReadOnlyList<IDomainEvent> DomainEvents => _domainEvents;

        public void AddDomainEvent(IDomainEvent newEvent)
        {
            if (!_domainEvents.Any())
            {
                Version++;
            }

            _domainEvents.Add(newEvent);
        }

        public void ClearEvents()
            => _domainEvents.Clear();

    }
}
