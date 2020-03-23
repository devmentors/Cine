using System;
using Cine.Shared.Exceptions;

namespace Cine.Reservations.Core.Exceptions
{
    public class EmptyReservationMovieException : DomainException
    {
        public override string ErrorCode => "empty_reservation_movie";

        public EmptyReservationMovieException(Guid reservationId)
            : base($"Empty movie defined for reservation with id {reservationId}")
        {
        }
    }
}
