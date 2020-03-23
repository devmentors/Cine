using Cine.Reservations.Core.Aggregates;
using Cine.Shared.BuildingBlocks;

namespace Cine.Reservations.Core.Events
{
    public class ReservationAdded : IDomainEvent
    {
        public Reservation Reservation { get; }

        public ReservationAdded(Reservation reservation)
        {
            Reservation = reservation;
        }
    }
}
