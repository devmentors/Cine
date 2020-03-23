using System;
using Cine.Shared.Exceptions;

namespace Cine.Reservations.Core.Exceptions
{
    public class EmptyReservationHallException : DomainException
    {
        public override string ErrorCode => "empty_reservation_hall";

        public EmptyReservationHallException(Guid reservationId)
            : base($"Empty hall defined for reservation with id {reservationId}")
        {
        }
    }
}
