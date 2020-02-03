using System.Collections.Generic;
using System.Threading.Tasks;
using Convey.CQRS.Events;

namespace Cine.Modules.Cinemas.Api.Services
{
    public interface IMessageBroker
    {
        Task PublishAsync(IEvent @event);
        Task PublishAsync(IEnumerable<IEvent> events);
    }
}
