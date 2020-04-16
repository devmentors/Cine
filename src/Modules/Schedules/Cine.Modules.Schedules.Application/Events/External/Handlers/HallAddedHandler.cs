using System.Threading.Tasks;
using Cine.Modules.Schedules.Core.Entities;
using Cine.Modules.Schedules.Core.Repositories;
using Cine.Shared.Events;

namespace Cine.Modules.Schedules.Application.Events.External.Handlers
{
    internal sealed class HallAddedHandler : IEventHandler<HallAdded>
    {
        private readonly IHallsRepository _hallsRepository;

        public HallAddedHandler(IHallsRepository hallsRepository)
        {
            _hallsRepository = hallsRepository;
        }

        public async Task HandleAsync(HallAdded @event)
        {
            if (await _hallsRepository.ExistsAsync(@event.HallId))
            {
                return;
            }

            var hall = new Hall(@event.HallId, @event.CinemaId);
            await _hallsRepository.AddAsync(hall);
        }
    }
}
