using Cine.Reservations.Core.Events;
using Cine.Reservations.Core.Exceptions;
using Cine.Reservations.Core.Types;
using Cine.Reservations.Core.ValueObjects;
using Cine.Shared.BuildingBlocks;

namespace Cine.Reservations.Core.Aggregates
{
    public class Reservation : AggregateRoot
    {
        public CinemaId CinemaId { get; }
        public MovieId MovieId { get; }
        public HallId HallId { get; }
        public Seat Seat { get; private set; }
        public ReservationStatus Status { get; private set; }

        public Reservation(EntityId id, CinemaId cinemaId, MovieId movieId, HallId hallId, Seat seat, ReservationStatus status)
            : base(id)
        {
            CinemaId = cinemaId ?? throw new EmptyReservationCinemaException(id);
            MovieId = movieId ?? throw new EmptyReservationMovieException(id);
            HallId = hallId ?? throw new EmptyReservationHallException(id);
            ChangeSeat(seat);
            ChangeStatus(status);
        }

        public static Reservation Create(EntityId id, CinemaId cinemaId, MovieId movieId, HallId hallId, Seat seat)
        {
            var reservation = new Reservation(id, cinemaId, movieId, hallId, seat, ReservationStatus.Pending);
            reservation.AddDomainEvent(new ReservationAdded(reservation));
            return reservation;
        }

        public void ChangeSeat(Seat seat)
        {
            Seat = seat ?? throw new EmptyReservationSeatException(Id);
            AddDomainEvent(new ReservationSeatChanged(this, seat));
        }

        public void ChangeStatus(ReservationStatus status)
        {
            Status = status;
            AddDomainEvent(new ReservationStatusChanged(this, status));
        }
    }
}
