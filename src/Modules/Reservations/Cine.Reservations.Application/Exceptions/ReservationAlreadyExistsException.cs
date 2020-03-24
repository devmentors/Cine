using Cine.Reservations.Core;
using Cine.Shared.Exceptions;

namespace Cine.Reservations.Application.Exceptions
{
    public class ReservationAlreadyExistsException : AppException
    {
        public override string ErrorCode => "reservation_already_exists";

        public ReservationAlreadyExistsException(MovieId movieId, string row, int number)
            : base($"Reservation {row}:{number} for movie with id {movieId} already exists.")
        {
        }
    }
}
