using Cine.Modules.Schedules.Api.Api;
using Cine.Modules.Schedules.Application;
using Cine.Modules.Schedules.Infrastructure;
using Convey;
using Microsoft.AspNetCore.Builder;

namespace Cine.Modules.Schedules.Api
{
    public static class Extensions
    {
        public static IConveyBuilder AddSchedulesModule(this IConveyBuilder builder)
            => builder.AddInfrastructure().AddApplication();

        public static IApplicationBuilder UseSchedulesModule(this IApplicationBuilder app)
            => app
                .UseSchedulesApi()
                .UseInfrastructure()
                .UseApplication();
    }
}
