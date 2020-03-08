using System;
using System.Threading.Tasks;
using Cine.Modules.Schedules.Application.DTO;

namespace Cine.Modules.Schedules.Application.Services
{
    public interface ISchedulesQueryService
    {
        Task<ScheduleDto> GetWeeklyScheduleAsync(Guid cinemaId, Guid movieId);
    }
}
