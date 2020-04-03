using System.Linq;
using Cine.Reservations.Core.Aggregates;

namespace Cine.Reservations.Infrastructure.Mongo.Documents
{
    internal static class Extensions
    {
        public static ReservationDocument AsDocument(this Reservation reservation)
            => new ReservationDocument
            {
                Id = reservation.Id,
                CinemaId = reservation.CinemaId,
                MovieId = reservation.MovieId,
                HallId = reservation.HallId,
                Reservee = new ReserveeDocument
                {
                    FullName = reservation.Reservee.FullName,
                    Email = reservation.Reservee.Email,
                    PhoneNumber = reservation.Reservee.PhoneNumber
                },
                Seats = reservation.Seats.Select(s => new SeatDocument
                {
                    Row = s.Row,
                    Number = s.Number,
                    Price = s.Price,
                    IsVip = s.IsVip
                }),
                Status = reservation.Status.ToString(),
                Version = reservation.Version
            };

        public static Reservation AsEntity
    }
}
