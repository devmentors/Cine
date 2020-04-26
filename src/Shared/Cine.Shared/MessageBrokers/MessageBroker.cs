using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cine.Shared.Modules;
using Convey.CQRS.Events;
using Microsoft.Extensions.Logging;

namespace Cine.Shared.MessageBrokers
{
    internal sealed class MessageBroker : IMessageBroker
    {
        private readonly IModuleClient _client;
        private readonly ILogger<MessageBroker> _logger;

        public MessageBroker(IModuleClient client, ILogger<MessageBroker> logger)
        {
            _client = client;
            _logger = logger;
        }

        public async Task PublishAsync(IEvent @event)
        {
            _logger.LogTrace($"Publishing message of type {{{@event.GetType().Name}}}.");
            await _client.PublishAsync(@event);
            _logger.LogTrace($"Successfully published message of type {{{@event.GetType().Name}}}.");
        }

        public async Task PublishAsync(IEnumerable<IEvent> events)
        {
            var tasks = events.Select(PublishAsync).ToArray();
            await Task.WhenAll(tasks);
        }
    }
}
