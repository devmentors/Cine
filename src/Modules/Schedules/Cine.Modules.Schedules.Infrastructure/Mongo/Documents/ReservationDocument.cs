using System;

namespace Cine.Modules.Schedules.Infrastructure.Mongo.Documents
{
    public class ReservationDocument
    {
        public Guid HallId { get; set; }
        public DateTime Date { get; set; }
        public ScheduleTimeDocument Time { get; set; }
    }
}
