using System.Threading.Tasks;
using Cine.Modules.Cinemas.Api.DTO;
using Cine.Modules.Cinemas.Api.Services;
using Cine.Shared.IoC.Modules;

namespace Cine.Modules.Cinemas.Api.ModuleRequests.Handlers
{
    public sealed class HallModuleRequestHandler : IModuleRequestHandler<HallModuleRequest, HallDto>
    {
        private readonly ICinemasService _cinemasService;

        public HallModuleRequestHandler(ICinemasService cinemasService)
            => _cinemasService = cinemasService;

        public Task<HallDto> HandleAsync(HallModuleRequest request)
            => _cinemasService.GetHallAsync(request.HallId);
    }
}
