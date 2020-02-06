using System;
using System.Collections.Generic;
using Convey.Types;

namespace Cine.Modules.Schedules.Infrastructure.Mongo.Documents
{
    public class ScheduleDocument : IIdentifiable<Guid>
    {
        public Guid Id { get; set; }
        public Guid CinemaId { get; set; }
        public Guid MovieId { get; set; }
        public IEnumerable<ReservationDocument> Reservations { get; set; }
    }
}
