using System;
using Cine.Modules.Cinemas.Api.DTO;
using Cine.Shared.Modules;

namespace Cine.Modules.Cinemas.Api.ModuleRequests
{
    public class HallModuleRequest : IModuleRequest
    {
        public Guid HallId { get; set; }
    }
}
