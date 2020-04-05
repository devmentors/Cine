using System.Collections.Generic;
using System.Linq;
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
        private bool IsCompleted => Status is ReservationStatus.Completed || Status is ReservationStatus.Canceled;
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

        private Reservation(EntityId id, CinemaId cinemaId, MovieId movieId, HallId hallId)
            : base(id)
        {
            CinemaId = cinemaId ?? throw new EmptyReservationCinemaException(id);
            MovieId = movieId ?? throw new EmptyReservationMovieException(id);
            HallId = hallId ?? throw new EmptyReservationHallException(id);
        }

        public Reservation(EntityId id, CinemaId cinemaId, MovieId movieId, HallId hallId, ReservationStatus status,
            Reservee reservee, IEnumerable<Seat> seats, int? version = null)
            : this(id, cinemaId, movieId, hallId)
        {
            Status = status;
            Reservee = reservee;
            _seats = seats.ToHashSet();
            Version = version ?? 1;
        }

        public static Reservation Create(EntityId id, CinemaId cinemaId, MovieId movieId, HallId hallId,
            ReservationStatus status, Reservee reservee, IEnumerable<Seat> seats)
        {
            var reservation = new Reservation(id, cinemaId, movieId, hallId);

            reservation.ChangeStatus(status);
            reservation.ChangeReservee(reservee);
            reservation.AddSeats(seats);
            reservation.ClearEvents();
            reservation.AddDomainEvent(new ReservationAdded(reservation));
            reservation.Version = 1;

            return reservation;
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
    }
}
