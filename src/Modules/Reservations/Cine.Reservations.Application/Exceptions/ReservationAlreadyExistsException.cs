using System;
using Cine.Shared.Exceptions;

namespace Cine.Reservations.Application.Exceptions
{
    public class ReservationAlreadyExistsException : AppException
    {
        public override string ErrorCode => "reservation_already_exists";

        public ReservationAlreadyExistsException(Guid reservationId)
            : base($"Reservation with id: {reservationId} already exists")
        {
        }
    }
}
