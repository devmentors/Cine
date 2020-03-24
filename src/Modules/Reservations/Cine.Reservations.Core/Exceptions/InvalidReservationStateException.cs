using System;
using Cine.Shared.Exceptions;

namespace Cine.Reservations.Core.Exceptions
{
    public class InvalidReservationStateException : DomainException
    {
        public override string ErrorCode => "invalid_reservation_state";

        public InvalidReservationStateException(Guid reservationId)
            : base ($"Invalid state defined for reservation with id {reservationId}")
        {
        }
    }
}
