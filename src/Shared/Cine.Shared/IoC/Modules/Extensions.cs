using System;
using System.Linq;
using Cine.Shared.IoC.Registries;
using Convey;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace Cine.Shared.IoC.Modules
{
    public static class Extensions
    {
        public static IConveyBuilder AddModuleRequests(this IConveyBuilder builder)
        {
            builder.Services.AddSingleton<IModuleRequestsRegistry, ModuleRequestsRegistry>();
            builder.Services.AddSingleton<IModuleRequestSubscriber, ModuleRequestSubscriber>();
            return builder;
        }

        public static IModuleRequestSubscriber UseModuleRequests(this IApplicationBuilder app)
            => app.ApplicationServices.GetRequiredService<IModuleRequest>()
    }
}
