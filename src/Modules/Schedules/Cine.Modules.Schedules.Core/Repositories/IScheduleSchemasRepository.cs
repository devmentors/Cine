using System.Threading.Tasks;
using Cine.Modules.Schedules.Core.Aggregates;

namespace Cine.Modules.Schedules.Core.Repositories
{
    public interface IScheduleSchemasRepository
    {
        Task<ScheduleSchema> GetAsync(CinemaId cinemaId);
        Task<bool> ExistsAsync(CinemaId cinemaId);
        Task AddAsync(ScheduleSchema schema);
        Task UpdateAsync(ScheduleSchema schema);
    }
}
