using Cine.Reservations.Core.Aggregates;
using Cine.Reservations.Core.ValueObjects;
using Cine.Shared.BuildingBlocks;

namespace Cine.Reservations.Core.Events
{
    public class ReservationSeatAdded : IDomainEvent
    {
        public Reservation Reservation { get; }
        public Seat Seat { get; }

        public ReservationSeatAdded(Reservation reservation, Seat seat)
        {
            Reservation = reservation;
            Seat = seat;
        }
    }
}
