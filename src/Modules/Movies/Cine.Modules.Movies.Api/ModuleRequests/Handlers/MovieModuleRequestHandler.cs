using System.Threading.Tasks;
using Cine.Modules.Movies.Api.DTO;
using Cine.Modules.Movies.Api.Services;
using Cine.Shared.IoC.Modules;

namespace Cine.Modules.Movies.Api.ModuleRequests.Handlers
{
    public sealed class MovieModuleRequestHandler : IModuleRequestHandler<MovieModuleRequest, MovieDto>
    {
        private readonly IMoviesService _service;

        public MovieModuleRequestHandler(IMoviesService service)
            =>  _service = service;

        public Task<MovieDto> HandleAsync(MovieModuleRequest request)
            => _service.GetAsync(request.MovieId);
    }
}
