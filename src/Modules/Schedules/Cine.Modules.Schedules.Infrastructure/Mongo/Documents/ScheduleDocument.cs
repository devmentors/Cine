using System;
using System.Collections.Generic;

namespace Cine.Modules.Schedules.Infrastructure.Mongo.Documents
{
    public class ScheduleDocument
    {
        public Guid Id { get; set; }
        public Guid CinemaId { get; set; }
        public Guid MovieId { get; set; }
        public IEnumerable<ReservationDocument> Reservations { get; set; }
    }
}
