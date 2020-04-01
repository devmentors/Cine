using System;
using Cine.Shared.Exceptions;

namespace Cine.Reservations.Core.Exceptions
{
    public class EmptyReserveeException : DomainException
    {
        public override string ErrorCode => "empty_reservee";

        public EmptyReserveeException(Guid reservationId)
            : base($"Empty reservee defined for reservation with id: {reservationId}")
        {
        }
    }
}
