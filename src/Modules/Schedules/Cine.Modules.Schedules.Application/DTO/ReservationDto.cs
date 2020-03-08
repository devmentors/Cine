using System;

namespace Cine.Modules.Schedules.Application.DTO
{
    public class ReservationDto
    {
        public Guid HallId { get; set; }
        public DateTime DateTime { get; set; }
    }
}
