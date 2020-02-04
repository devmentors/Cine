using Cine.Modules.Schedules.Application;
using Convey;
using Microsoft.AspNetCore.Builder;

namespace Cine.Modules.Schedules.Infrastructure
{
    public static class Extensions
    {
        public static IConveyBuilder AddSchedulesModule(this IConveyBuilder builder)
            => builder.AddInfrastructure().AddApplication();

        public static IApplicationBuilder UseSchedulesModule(this IApplicationBuilder app)
            => app.UseInfrastructure().UseApplication();

        private static IConveyBuilder AddInfrastructure(this IConveyBuilder builder)
        {
            return builder;
        }

        private static IApplicationBuilder UseInfrastructure(this IApplicationBuilder app)
        {
            return app;
        }
    }
}
