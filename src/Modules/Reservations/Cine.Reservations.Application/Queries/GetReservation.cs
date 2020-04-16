using System;
using Cine.Reservations.Application.DTO;

namespace Cine.Reservations.Application.Queries
{
    public class GetReservation : IQuery<ReservationDto>
    {
        public Guid ReservationId { get; set; }
    }
}
