using Convey;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace Cine.Shared.Modules
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
