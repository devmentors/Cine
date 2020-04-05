using System;
using System.Threading.Tasks;
using Cine.Reservations.Application.DTO;

namespace Cine.Reservations.Application.Services
{
    public interface IReservationsQueryService
    {
        Task<ReservationDto> GetAsync(Guid id);
    }
}
