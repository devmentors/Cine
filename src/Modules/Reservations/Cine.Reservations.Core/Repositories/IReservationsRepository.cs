using System;
using System.Threading.Tasks;
using Cine.Reservations.Core.Aggregates;
using Cine.Reservations.Core.Types;

namespace Cine.Reservations.Core.Repositories
{
    public interface IReservationsRepository
    {
        Task<Reservation> GetAsync(Guid id);
        Task<bool> ExistsAsync(ReservationKey key);
        Task AddAsync(Reservation reservation);
        Task UpdateAsync(Reservation reservation);
    }
}
