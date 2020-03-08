using System.Threading.Tasks;
using Cine.Modules.Schedules.Application.DTO.External;
using Cine.Modules.Schedules.Application.ModuleRequest;
using Cine.Modules.Schedules.Application.Services.Clients;
using Cine.Modules.Schedules.Core;
using Cine.Shared.Modules;

namespace Cine.Modules.Schedules.Infrastructure.Services.Clients
{
    internal sealed class MoviesApiClient : IMoviesApiClient
    {
        private readonly IModuleClient _client;

        public MoviesApiClient(IModuleClient client)
            => _client = client;

        public Task<MovieDto> GetAsync(MovieId movieId)
            => _client.GetAsync<MovieDto>("modules/movies/details", new { MovieId = movieId.Value });
    }
}
