using System;
using Cine.Shared.Exceptions;

namespace Cine.Reservations.Core.Exceptions
{
    public class EmptyReservationSeatException : DomainException
    {
        public override string ErrorCode => "empty_reservation_seat";

        public EmptyReservationSeatException(Guid reservationId)
            : base($"Empty seat defined for reservation with id {reservationId}")
        {
        }
    }
}
