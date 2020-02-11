using System.Collections.Generic;
using System.Threading.Tasks;
using Cine.Shared.BuildingBlocks;

namespace Cine.Shared.Events
{
    public interface IEventProcessor
    {
        Task ProcessAsync(IEnumerable<IDomainEvent> events);
    }
}
