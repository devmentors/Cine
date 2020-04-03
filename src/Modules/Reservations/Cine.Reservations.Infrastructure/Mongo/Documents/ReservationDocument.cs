using System;
using System.Collections.Generic;
using Convey.Types;

namespace Cine.Reservations.Infrastructure.Mongo.Documents
{
    public class ReservationDocument : IIdentifiable<Guid>
    {
        public Guid Id { get; set; }
        public Guid CinemaId { get; set; }
        public Guid MovieId { get; set; }
        public Guid HallId { get; set; }
        public string Status { get; set; }
        public ReserveeDocument Reservee { get; set; }
        public IEnumerable<SeatDocument> Seats { get; set; }
        public int Version { get; set; }
    }
}
