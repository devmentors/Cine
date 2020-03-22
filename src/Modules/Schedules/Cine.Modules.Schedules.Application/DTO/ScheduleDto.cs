using System;
using System.Collections.Generic;

namespace Cine.Modules.Schedules.Application.DTO
{
    public class ScheduleDto
    {
        public Guid Id { get; set; }
        public Guid CinemaId { get; set; }
        public Guid MovieId { get; set; }
        public IEnumerable<ShowDto> Shows { get; set; }
    }
}
