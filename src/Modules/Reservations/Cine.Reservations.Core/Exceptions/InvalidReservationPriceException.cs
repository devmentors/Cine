using System;
using Cine.Shared.Exceptions;

namespace Cine.Reservations.Core.Exceptions
{
    public class InvalidReservationPriceException : DomainException
    {
        public override string ErrorCode => "invalid_reservation_price";

        public InvalidReservationPriceException(Guid reservationId)
            : base($"Invalid price defined for reservation with id {reservationId}")
        {

        }
    }
}
