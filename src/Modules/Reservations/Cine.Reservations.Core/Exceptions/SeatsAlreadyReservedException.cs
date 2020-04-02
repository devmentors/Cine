using Cine.Shared.BuildingBlocks;
using Cine.Shared.Exceptions;

namespace Cine.Reservations.Core.Exceptions
{
    public class SeatsAlreadyReservedException : DomainException
    {
        public override string ErrorCode => "seat_already_reserved";

        public SeatsAlreadyReservedException(EntityId reservationId)
            : base($"Seats for reservation with id: {reservationId} has already been reserved by someone else")
        {
        }
    }
}
