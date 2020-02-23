using System;
using Cine.Modules.Schedules.Application.DTO.External;
using Cine.Shared.IoC.Modules;

namespace Cine.Modules.Schedules.Application.ModuleRequest
{
    public class MovieModuleRequest : IModuleRequest
    {
        public Guid MovieId { get; set; }
    }
}
