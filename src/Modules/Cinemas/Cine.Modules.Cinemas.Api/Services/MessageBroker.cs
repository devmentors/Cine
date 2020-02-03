using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Convey.CQRS.Events;

namespace Cine.Modules.Cinemas.Api.Services
{
    internal sealed class MessageBroker : IMessageBroker
    {
        private readonly IEventDispatcher _dispatcher;

        public MessageBroker(IEventDispatcher dispatcher)
            => _dispatcher = dispatcher;

        public Task PublishAsync(IEvent @event)
            => _dispatcher.PublishAsync(@event);

        public async Task PublishAsync(IEnumerable<IEvent> events)
        {
            var tasks = events.Select(e => _dispatcher.PublishAsync(e));
            await Task.WhenAll(tasks);
        }
    }
}
