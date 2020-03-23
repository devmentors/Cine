using System;
using Cine.Shared.Exceptions;

namespace Cine.Reservations.Core.Exceptions
{
    public class EmptyReservationCinemaException : DomainException
    {
        public override string ErrorCode => "empty_reservation_cinema";

        public EmptyReservationCinemaException(Guid reservationId)
            : base($"Empty cinema defined for reservation with id {reservationId}")
        {
        }
    }
}
