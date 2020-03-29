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
        public bool IsPaymentUponArrival { get; }
        public string Row { get; }
        public int Number { get; }
        public decimal Price { get; }
        public bool IsVip { get; }
        public bool IsGuest { get; }
        public string GuestFullName { get; }
        public string GuestEmail { get; }
        public string GuestFullNumber { get; }

        public CreateReservation(Guid id, Guid cinemaId, Guid movieId, Guid hallId, bool isPaymentUponArrival,
            string row, int number, decimal price, bool isVip, bool isGuest, string guestFullName,
            string guestEmail, string guestFullNumber)
        {
            Id = id;
            CinemaId = cinemaId;
            MovieId = movieId;
            HallId = hallId;
            IsPaymentUponArrival = isPaymentUponArrival;
            Row = row;
            Number = number;
            Price = price;
            IsVip = isVip;
            IsGuest = isGuest;
            GuestFullName = guestFullName;
            GuestEmail = guestEmail;
            GuestFullNumber = guestFullNumber;
        }
    }
}
