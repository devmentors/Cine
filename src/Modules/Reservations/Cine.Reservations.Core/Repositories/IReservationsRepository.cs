using System.Threading.Tasks;
using Cine.Reservations.Core.Aggregates;
using Cine.Shared.BuildingBlocks;

namespace Cine.Reservations.Core.Repositories
{
    public interface IReservationsRepository
    {
        Task<Reservation> GetAsync(EntityId id);
        Task<bool> ExistsAsync(EntityId id);
        Task AddAsync(Reservation reservation);
        Task UpdateAsync(Reservation reservation);
    }
}
