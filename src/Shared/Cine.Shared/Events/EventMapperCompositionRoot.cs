using System.Collections.Generic;
using System.Linq;
using Cine.Shared.BuildingBlocks;
using Convey.CQRS.Events;
using Microsoft.Extensions.DependencyInjection;

namespace Cine.Shared.Events
{
    internal sealed class EventMapperCompositionRoot : IEventMapperCompositionRoot
    {
        private readonly IServiceScopeFactory _serviceScopeFactory;

        public EventMapperCompositionRoot(IServiceScopeFactory serviceScopeFactory)
            =>  _serviceScopeFactory = serviceScopeFactory;

        public IEvent Map(IDomainEvent domainEvent)
        {
            using var scope = _serviceScopeFactory.CreateScope();
            var mappers = scope.ServiceProvider.GetService<IEnumerable<IEventMapper>>();

            return mappers
                ?.Select(mapper => mapper.Map(domainEvent))
                 .SingleOrDefault(@event => @event is {});
        }

        public IEnumerable<IEvent> MapAll(IEnumerable<IDomainEvent> domainEvents)
            => domainEvents.Select(Map);
    }
}
