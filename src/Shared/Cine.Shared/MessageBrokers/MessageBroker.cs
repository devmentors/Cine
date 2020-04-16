using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cine.Shared.Events;
using Cine.Shared.Modules;

namespace Cine.Shared.MessageBrokers
{
    internal sealed class MessageBroker : IMessageBroker
    {
        private readonly IModuleClient _client;

        public MessageBroker(IModuleClient client)
            => _client = client;

        public Task PublishAsync(IEvent @event)
            => _client.PublishAsync(@event);

        public async Task PublishAsync(IEnumerable<IEvent> events)
        {
            var tasks = events.Select(e => _client.PublishAsync(e)).ToArray();
            await Task.WhenAll(tasks);
        }
    }
}
