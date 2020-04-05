using System;
using System.Threading.Tasks;
using Cine.Reservations.Core.ValueObjects;

namespace Cine.Reservations.Core.Services
{
    public interface IReserveesProvider
    {
        Task<Reservee> GetAsync(Guid customerId);
    }
}
