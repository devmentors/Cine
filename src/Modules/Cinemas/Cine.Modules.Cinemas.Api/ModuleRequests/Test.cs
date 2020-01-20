using System;
using System.Threading.Tasks;
using Cine.Modules.Cinemas.Api.DTO;
using Cine.Shared.IoC.Modules;

namespace Cine.Modules.Cinemas.Api.ModuleRequests
{
    public class CinemaModuleRequest : IModuleRequest<CinemaDto>
    {
        public Guid CinemaId { get; set; }
    }

    public class Test : IModuleRequestHandler<CinemaModuleRequest, CinemaDto>
    {
        public Task<CinemaDto> HandleAsync(CinemaModuleRequest request)
            => Task.FromResult(new CinemaDto {Id = request.CinemaId, Name = "Test 2137"});
    }
}
