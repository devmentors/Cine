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
            builder.Services.AddSingleton<IModuleRequestSubscriber, ModuleRequestSubscriber>();
            builder.Services.AddTransient<IModuleRequestClient, ModuleRequestClient>();

            return builder;
        }

        public static IModuleRequestSubscriber UseModuleRequests(this IApplicationBuilder app)
            => app.ApplicationServices.GetRequiredService<IModuleRequestSubscriber>();
    }
}
