using System;
using Cine.Shared.Exceptions;

namespace Cine.Reservations.Application.Exceptions
{
    public class ReservationNotFoundException : AppException
    {
        public override string ErrorCode => "reservation_not_found";

        public ReservationNotFoundException(Guid reservationId)
            : base($"Reservation with id {reservationId} was not found")
        {
        }
    }
}
