using System;
using System.Collections.Generic;
using System.Windows.Input;
using Cine.Reservations.Application.Commands.WriteModels;

namespace Cine.Reservations.Application.Commands
{
    public class CreateReservation : ICommand
    {
        public Guid Id { get; }
        public Guid CinemaId { get; }
        public Guid MovieId { get; }
        public Guid HallId { get; }
        public Guid? CustomerId { get; }
        public bool IsPaymentUponArrival { get; }
        public IEnumerable<SeatWriteModel> Seats { get; }
        public ReserveeWriteModel Reservee { get; }

        public CreateReservation(Guid id, Guid cinemaId, Guid movieId, Guid hallId, Guid? customerId,
            bool isPaymentUponArrival, IEnumerable<SeatWriteModel> seats, ReserveeWriteModel reservee)
        {
            Id = id;
            CinemaId = cinemaId;
            MovieId = movieId;
            HallId = hallId;
            CustomerId = customerId;
            IsPaymentUponArrival = isPaymentUponArrival;
            Seats = seats;
            Reservee = reservee;
        }
    }
}
