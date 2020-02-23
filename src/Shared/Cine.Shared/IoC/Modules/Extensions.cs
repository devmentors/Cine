using System;
using System.Linq;
using Cine.Shared.IoC.Types;
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
            builder.Services.AddSingleton<IModuleRequestMapper, ModuleRequestMapper>();
            builder.Services.AddTransient<IModuleRequestClient, ModuleRequestClient>();

            return builder;
        }

        public static IModuleRequestMapper UseModuleRequests(this IApplicationBuilder app)
            => app.ApplicationServices.GetRequiredService<IModuleRequestMapper>();
    }
}
