using System.Collections.Generic;
using System.Threading.Tasks;
using Cine.Modules.Schedules.Core.Aggregates;
using Cine.Shared.BuildingBlocks;

namespace Cine.Modules.Schedules.Core.Repositories
{
    public interface ISchedulesRepository
    {
        Task<IEnumerable<Schedule>> GetAsync();
        Task<Schedule> GetAsync(EntityId id);
        Task AddAsync(Schedule schedule);
        Task UpdateAsync(Schedule schedule);
        Task DeleteAsync(EntityId id);
    }
}
