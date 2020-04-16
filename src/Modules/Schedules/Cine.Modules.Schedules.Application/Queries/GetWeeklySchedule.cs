using System;
using Cine.Modules.Schedules.Application.DTO;
using Cine.Shared.Queries;

namespace Cine.Modules.Schedules.Application.Queries
{
    public class GetWeeklySchedule : IQuery<ScheduleDto>
    {
        public Guid CinemaId { get; set; }
        public Guid MovieId { get; set; }
    }
}
