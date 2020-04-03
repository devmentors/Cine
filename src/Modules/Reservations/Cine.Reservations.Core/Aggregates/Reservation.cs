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
        public Reservee Reservee { get; private set; }
        public ISet<Seat> Seats
        {
            get => _seats;
            private set => _seats = new HashSet<Seat>(value);
        }

        public Reservation(EntityId id, CinemaId cinemaId, MovieId movieId, HallId hallId, ReservationStatus status,
            Reservee reservee, IEnumerable<Seat> seats, int? version = null)
            : base(id)
        {
            CinemaId = cinemaId ?? throw new EmptyReservationCinemaException(id);
            MovieId = movieId ?? throw new EmptyReservationMovieException(id);
            HallId = hallId ?? throw new EmptyReservationHallException(id);
            ChangeStatus(status);
            ChangeReservee(reservee);
            AddSeats(seats);
            Version = version ?? 1;
        }

        public void ChangeReservee(Reservee reservee)
        {
            _ = reservee ?? throw new EmptyReserveeException(Id);
            Reservee = reservee;
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
                AddDomainEvent(new ReservationSeatAdded(this, seat));
            }
        }

        public void AddSeats(IEnumerable<Seat> seats)
        {
            foreach (var seat in seats)
            {
                AddSeat(seat);
            }
        }

        public void RemoveSeat(Seat seat)
        {
            if (!_seats.Remove(seat))
            {
                return;
            }

            AddDomainEvent(new ReservationSeatRemoved(this, seat));
        }

        public void RemoveSeats(IEnumerable<Seat> seats)
        {
            foreach (var seat in seats)
            {
                RemoveSeat(seat);
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
