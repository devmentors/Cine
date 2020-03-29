using System.Collections.Generic;
using Cine.Reservations.Core.Events;
using Cine.Reservations.Core.Exceptions;
using Cine.Reservations.Core.Types;
using Cine.Reservations.Core.ValueObjects;
using Cine.Shared.BuildingBlocks;

namespace Cine.Reservations.Core.Aggregates
{
    public class Reservation : AggregateRoot
    {
        private HashSet<Seat> _seats = new HashSet<Seat>();
        private bool IsCompleted => Status is ReservationStatus.Paid || Status is ReservationStatus.Canceled;

        public CinemaId CinemaId { get; }
        public MovieId MovieId { get; }
        public HallId HallId { get; }
        public ReservationStatus Status { get; private set; }
        public ISet<Seat> Seats
        {
            get => _seats;
            private set => _seats = new HashSet<Seat>(value);
        }

        public Reservation(EntityId id, CinemaId cinemaId, MovieId movieId, HallId hallId, ReservationStatus status,
            IEnumerable<Seat> seats, int? version = null) : base(id)
        {
            CinemaId = cinemaId ?? throw new EmptyReservationCinemaException(id);
            MovieId = movieId ?? throw new EmptyReservationMovieException(id);
            HallId = hallId ?? throw new EmptyReservationHallException(id);
            AddSeats(seats);
            ChangeStatus(status);
            Version = version ?? 1;
        }

        public static Reservation Create(EntityId id, CinemaId cinemaId, MovieId movieId, HallId hallId,
            bool isPaymentUponArrival, IEnumerable<Seat> seats)
        {
            var status = isPaymentUponArrival ? ReservationStatus.PaymentUponArrival : ReservationStatus.Pending;
            var reservation = new Reservation(id, cinemaId, movieId, hallId, status, seats);
            reservation.ClearEvents();
            reservation.AddDomainEvent(new ReservationAdded(reservation));
            return reservation;
        }

        public void AddSeat(Seat seat)
        {
            _ = seat ?? throw new EmptyReservationSeatException(Id);

            if (IsCompleted)
            {
                throw new InvalidReservationChangeException(Id, Status);
            }

            if(_seats.Add(seat))
            {
                AddDomainEvent(new ReservationSeatChanged(this, seat));
            }
        }

        public void AddSeats(IEnumerable<Seat> seats)
        {
            foreach (var seat in seats)
            {
                AddSeat(seat);
            }
        }

        public void ChangeStatus(ReservationStatus status)
        {
            if (IsCompleted)
            {
                throw new InvalidReservationChangeException(Id, Status);
            }

            Status = status;
            AddDomainEvent(new ReservationStatusChanged(this, status));
        }
    }
}
