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
        public decimal Price { get; private set; }
        public Seat Seat { get; private set; }
        public ReservationStatus Status { get; private set; }

        public Reservation(EntityId id, CinemaId cinemaId, MovieId movieId, HallId hallId, decimal price, Seat seat,
            ReservationStatus status, int? version = null) : base(id)
        {
            CinemaId = cinemaId ?? throw new EmptyReservationCinemaException(id);
            MovieId = movieId ?? throw new EmptyReservationMovieException(id);
            HallId = hallId ?? throw new EmptyReservationHallException(id);
            ChangePrice(price);
            ChangeSeat(seat);
            ChangeStatus(status);
            Version = version ?? 1;
        }

        public static Reservation Create(EntityId id, CinemaId cinemaId, MovieId movieId, HallId hallId, decimal price, Seat seat)
        {
            var reservation = new Reservation(id, cinemaId, movieId, hallId, price, seat, ReservationStatus.Pending);
            reservation.ClearEvents();
            reservation.AddDomainEvent(new ReservationAdded(reservation));
            return reservation;
        }

        public void ChangePrice(decimal price)
        {
            if (price <= 0)
            {
                throw new InvalidReservationPriceException(Id);
            }

            Price = price;
            AddDomainEvent(new ReservationPriceChanged(this, price));
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
