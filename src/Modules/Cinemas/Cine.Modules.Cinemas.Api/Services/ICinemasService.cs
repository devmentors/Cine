using System;
using System.Threading.Tasks;
using Cine.Modules.Cinemas.Api.DTO;

namespace Cine.Modules.Cinemas.Api.Services
{
    public interface ICinemasService
    {
        Task<CinemaDto> GetAsync(Guid id);
        Task<HallDto> GetHallAsync(Guid hallId);
        Task CreateAsync(CinemaDto dto);
        Task UpdateAsync(CinemaDto dto);
        Task DeleteAsync(Guid id);
    }
}
