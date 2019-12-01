using System.Collections.Generic;
using Cinema.Shared.Exceptions;

namespace Cinema.Shared.BuildingBlocks
{
    public abstract class AggregateRoot : IEntity
    {
        public EntityId Id { get; protected set; }

        protected AggregateRoot(EntityId id)
        {
            if (id is null || id.IsEmpty())
                throw new EmptyAggregateIdException();

            Id = id;
        }


        private readonly List<IDomainEvent> _domainEvents = new List<IDomainEvent>();

        public virtual IReadOnlyList<IDomainEvent> DomainEvents => _domainEvents;

        protected virtual void AddDomainEvent(IDomainEvent newEvent)
            => _domainEvents.Add(newEvent);

        public virtual void ClearEvents()
            => _domainEvents.Clear();

    }
}
