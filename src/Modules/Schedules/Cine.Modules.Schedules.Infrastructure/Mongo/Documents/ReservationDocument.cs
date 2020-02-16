using System;

namespace Cine.Modules.Schedules.Infrastructure.Mongo.Documents
{
    public class ReservationDocument
    {
        public Guid HallId { get; set; }
        public DateTime DateTime { get; set; }
    }
}
