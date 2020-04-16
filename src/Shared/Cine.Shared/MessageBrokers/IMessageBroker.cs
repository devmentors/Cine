using System.Collections.Generic;
using System.Threading.Tasks;
using Cine.Shared.Events;

namespace Cine.Shared.MessageBrokers
{
    public interface IMessageBroker
    {
        Task PublishAsync(IEvent @event);
        Task PublishAsync(IEnumerable<IEvent> events);
    }
}
