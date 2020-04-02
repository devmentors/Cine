using Cine.Reservations.Core.Aggregates;
using Cine.Reservations.Core.ValueObjects;
using Cine.Shared.BuildingBlocks;

namespace Cine.Reservations.Core.Events
{
    public class ReservationSeatRemoved : IDomainEvent
    {
        public Reservation Reservation { get; }
        public Seat Seat { get; }

        public ReservationSeatRemoved(Reservation reservation, Seat seat)
        {
            Reservation = reservation;
            Seat = seat;
        }
    }
}
