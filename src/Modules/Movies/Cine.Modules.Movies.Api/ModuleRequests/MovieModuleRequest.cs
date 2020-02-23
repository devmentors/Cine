using System;
using Cine.Modules.Movies.Api.DTO;
using Cine.Shared.Modules;

namespace Cine.Modules.Movies.Api.ModuleRequests
{
    public class MovieModuleRequest : IModuleRequest
    {
        public Guid MovieId { get; set; }
    }
}
