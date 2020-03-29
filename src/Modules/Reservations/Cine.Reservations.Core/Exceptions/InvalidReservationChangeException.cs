using System;
using Cine.Reservations.Core.Types;
using Cine.Shared.Exceptions;

namespace Cine.Reservations.Core.Exceptions
{
    public class InvalidReservationChangeException : DomainException
    {
        public override string ErrorCode => "invalid_reservation_change";

        public InvalidReservationChangeException(Guid reservationId, ReservationStatus status)
            : base($"Changing reservation with id {reservationId} is invalid due to its status: {status}")
        {
        }
    }
}
