using System.Collections.Generic;
using System.Threading.Tasks;
using Convey.CQRS.Events;

namespace Cine.Shared.MessageBrokers
{
    public interface IMessageBroker
    {
        Task PublishAsync(IEvent @event);
        Task PublishAsync(IEnumerable<IEvent> events);
    }
}
