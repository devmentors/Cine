using System;
using Cine.Reservations.Application.DTO;
using Convey.CQRS.Queries;

namespace Cine.Reservations.Application.Queries
{
    public class GetReservation : IQuery<ReservationDto>
    {
        public Guid Id { get; set; }
    }
}
