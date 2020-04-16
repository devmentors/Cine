using Cine.Modules.Schedules.Api.Api;
using Cine.Modules.Schedules.Application;
using Cine.Modules.Schedules.Infrastructure;
using Convey;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace Cine.Modules.Schedules.Api
{
    public static class Extensions
    {
        public static IServiceCollection AddSchedulesModule(this IServiceCollection services)
            => services.AddInfrastructure().AddApplication();

        public static IApplicationBuilder UseSchedulesModule(this IApplicationBuilder app)
            => app
                .UseSchedulesApi()
                .UseInfrastructure()
                .UseApplication();
    }
}
