using System;
using Convey.CQRS.Commands;

namespace Cine.Reservations.Application.Commands
{
    public class CreateReservation : ICommand
    {
        public Guid Id { get; }
        public Guid CinemaId { get; }
        public Guid MovieId { get; }
        public Guid HallId { get; }
        public string Row { get; }
        public int Number { get; }
        public decimal Price { get; }
        public bool IsVip { get; }

        public CreateReservation(Guid id, Guid cinemaId, Guid movieId, Guid hallId, string row, int number,
            decimal price, bool isVip)
        {
            Id = id;
            CinemaId = cinemaId;
            MovieId = movieId;
            HallId = hallId;
            Row = row;
            Number = number;
            Price = price;
            IsVip = isVip;
        }
    }
}
