using System.Threading.Tasks;
using Cine.Modules.Schedules.Core.Aggregates;
using Cine.Modules.Schedules.Core.Entities;
using Cine.Shared.BuildingBlocks;

namespace Cine.Modules.Schedules.Core.Repositories
{
    public interface IScheduleSchemasRepository
    {
        Task<ScheduleSchema> GetAsync(CinemaId cinemaId);
        Task AddAsync(ScheduleSchema schema);
        Task UpdateAsync(ScheduleSchema schema);
    }
}
