using Cine.Reservations.Core.Aggregates;
using Cine.Reservations.Core.Types;
using Cine.Shared.BuildingBlocks;

namespace Cine.Reservations.Core.Events
{
    public class ReservationStatusChanged : IDomainEvent
    {
        public Reservation Reservation { get; }
        public ReservationStatus Status { get; }

        public ReservationStatusChanged(Reservation reservation, ReservationStatus status)
        {
            Reservation = reservation;
            Status = status;
        }
    }
}
