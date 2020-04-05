using System.Collections.Generic;
using System.Linq;
using Cine.Reservations.Application.Events;
using Cine.Reservations.Core.Events;
using Cine.Shared.BuildingBlocks;
using Cine.Shared.Events;
using Convey.CQRS.Events;

namespace Cine.Reservations.Infrastructure.Services
{
    internal sealed class EventMapper : IEventMapper
    {
        public IEvent Map(IDomainEvent domainEvent)
            => domainEvent switch
            {
                ReservationAdded @event => new ReservationCreated(@event.Reservation.Id),
                _ => null
            };

        public IEnumerable<IEvent> MapAll(IEnumerable<IDomainEvent> domainEvents)
            => domainEvents.Select(Map);
    }
}
