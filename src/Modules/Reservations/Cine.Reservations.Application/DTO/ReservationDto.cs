using System;
using System.Collections.Generic;

namespace Cine.Reservations.Application.DTO
{
    public class ReservationDto
    {
        public Guid Id { get; set; }
        public Guid CinemaId { get; set; }
        public Guid MovieId { get; set; }
        public Guid HallId { get; set; }
        public string Status { get; set; }
        public ReserveeDto Reservee { get; set; }
        public IEnumerable<SeatDto> Seats { get; set; }
    }
}
