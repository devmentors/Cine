using System;
using Cine.Modules.Cinemas.Api.DTO;
using Cine.Shared.IoC.Modules;

namespace Cine.Modules.Cinemas.Api.ModuleRequests
{
    public class HallModuleRequest : IModuleRequest
    {
        public Guid HallId { get; set; }
    }
}
