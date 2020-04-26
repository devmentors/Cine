using System.Collections.Generic;
using System.Threading.Tasks;
using Cine.Shared.BuildingBlocks;
using Cine.Shared.MessageBrokers;
using Convey.CQRS.Events;
using Microsoft.Extensions.Logging;

namespace Cine.Shared.Events
{
    internal sealed class EventProcessor : IEventProcessor
    {
        private readonly IMessageBroker _broker;
        private readonly IEventMapperCompositionRoot _eventMapperCompositionRoot;
        private readonly ILogger<IEventProcessor> _logger;

        public EventProcessor(IMessageBroker broker, IEventMapperCompositionRoot eventMapperCompositionRoot,
            ILogger<IEventProcessor> logger)
        {
            _broker = broker;
            _eventMapperCompositionRoot = eventMapperCompositionRoot;
            _logger = logger;
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
                _logger.LogTrace($"Processing domain event of type {{{@event.GetType().Name}}}");

                var integrationEvent = _eventMapperCompositionRoot.Map(@event);

                if (integrationEvent is null)
                {
                    continue;
                }

                integrationEvents.Add(integrationEvent);
                _logger.LogTrace($"Mapped domain event of type {{{@event.GetType().Name}}} to integration " +
                                 $"event of type {integrationEvent.GetType().Name}");
            }

            await _broker.PublishAsync(integrationEvents);
        }
    }
}
