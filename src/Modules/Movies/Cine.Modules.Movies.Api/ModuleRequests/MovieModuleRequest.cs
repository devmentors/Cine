using System;
using Cine.Modules.Movies.Api.DTO;
using Cine.Shared.IoC.Modules;

namespace Cine.Modules.Movies.Api.ModuleRequests
{
    public class MovieModuleRequest : IModuleRequest<MovieDto>
    {
        public Guid MovieId { get; set; }
    }
}
