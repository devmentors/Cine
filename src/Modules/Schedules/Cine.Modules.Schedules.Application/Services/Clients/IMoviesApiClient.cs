using System.Threading.Tasks;
using Cine.Modules.Schedules.Application.DTO.External;
using Cine.Modules.Schedules.Core;

namespace Cine.Modules.Schedules.Application.Services.Clients
{
    public interface IMoviesApiClient
    {
        Task<MovieDto> GetAsync(MovieId movieId);
    }
}
