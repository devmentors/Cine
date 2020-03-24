using System;
using System.Threading.Tasks;
using Cine.Reservations.Core.Aggregates;

namespace Cine.Reservations.Core.Repositories
{
    public interface IReservationsRepository
    {
        Task<Reservation> GetAsync(Guid id);
        Task<bool> ExistsAsync(Guid id);
        Task AddAsync(Reservation reservation);
        Task UpdateAsync(Reservation reservation);
    }
}
