using System.Collections.Generic;
using System.Threading.Tasks;
using Cine.Reservations.Core.ValueObjects;

namespace Cine.Reservations.Core.Validators
{
    public interface IReservationSeatsValidator
    {
        Task<bool> ValidateAsync(IEnumerable<Seat> seats);
    }
}
