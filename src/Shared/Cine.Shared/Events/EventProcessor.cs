using System.Collections.Generic;
using System.Threading.Tasks;
using Cine.Shared.BuildingBlocks;
using Cine.Shared.MessageBrokers;
using Convey.CQRS.Events;

namespace Cine.Shared.Events
{
    internal sealed class EventProcessor : IEventProcessor
    {
        private readonly IMessageBroker _broker;
        private readonly IEventMapperCompositionRoot _eventMapperCompositionRoot;

        public EventProcessor(IMessageBroker broker, IEventMapperCompositionRoot eventMapperCompositionRoot)
        {
            _broker = broker;
            _eventMapperCompositionRoot = eventMapperCompositionRoot;
        }

        public async Task ProcessAsync(IEnumerable<IDomainEvent> events)
        {
            if (events is null)
            {
                return;
            }

            var integrationEvents = new List<IEvent>();

            foreach (var @event in events)
            {
                var integrationEvent = _eventMapperCompositionRoot.Map(@event);

                if (integrationEvent is null)
                {
                    continue;
                }

                integrationEvents.Add(integrationEvent);
            }

            await _broker.PublishAsync(integrationEvents);
        }
    }
}
