using Cine.Shared.BuildingBlocks;
using Cine.Shared.Exceptions;

namespace Cine.Reservations.Core.Exceptions
{
    public class EmptyReservationTimeException : DomainException
    {
        public override string ErrorCode => "empty_reservation_time";

        public EmptyReservationTimeException(EntityId reservationId)
            : base($"Empty time defined for reservation with id {reservationId}")
        {

        }
    }
}
