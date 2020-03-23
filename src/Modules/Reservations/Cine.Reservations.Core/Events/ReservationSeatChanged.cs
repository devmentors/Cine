using Cine.Reservations.Core.Aggregates;
using Cine.Reservations.Core.ValueObjects;
using Cine.Shared.BuildingBlocks;

namespace Cine.Reservations.Core.Events
{
    public class ReservationSeatChanged : IDomainEvent
    {
        public Reservation Reservation { get; }
        public Seat Seat { get; }

        public ReservationSeatChanged(Reservation reservation, Seat seat)
        {
            Reservation = reservation;
            Seat = seat;
        }
    }
}
