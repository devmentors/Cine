using System.Threading.Tasks;
using Cine.Modules.Schedules.Application.DTO.External;
using Cine.Modules.Schedules.Application.ModuleRequest;
using Cine.Modules.Schedules.Application.Services.Clients;
using Cine.Modules.Schedules.Core;
using Cine.Shared.IoC.Modules;

namespace Cine.Modules.Schedules.Infrastructure.Services.Clients
{
    internal sealed class MoviesApiClient : IMoviesApiClient
    {
        private readonly IModuleRequestDispatcher _dispatcher;

        public MoviesApiClient(IModuleRequestDispatcher dispatcher)
            => _dispatcher = dispatcher;

        public Task<MovieDto> GetAsync(MovieId movieId)
            => _dispatcher.RequestAsync<MovieModuleRequest, MovieDto>(new MovieModuleRequest {MovieId = movieId});
    }
}
