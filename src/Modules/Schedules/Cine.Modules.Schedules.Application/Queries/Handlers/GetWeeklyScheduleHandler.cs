using System.Threading.Tasks;
using Cine.Modules.Schedules.Application.DTO;
using Cine.Modules.Schedules.Application.Services;
using Cine.Shared.Queries;

namespace Cine.Modules.Schedules.Application.Queries.Handlers
{
    public sealed class GetWeeklyScheduleHandler : IQueryHandler<GetWeeklySchedule, ScheduleDto>
    {
        private readonly ISchedulesQueryService _queryService;

        public GetWeeklyScheduleHandler(ISchedulesQueryService queryService)
            => _queryService = queryService;

        public Task<ScheduleDto> HandleAsync(GetWeeklySchedule query)
            => _queryService.GetWeeklyScheduleAsync(query.CinemaId, query.MovieId);
    }
}
