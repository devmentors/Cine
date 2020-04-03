using Convey;
using Microsoft.AspNetCore.Builder;

namespace Cine.Reservations.Infrastructure
{
    public static class Extensions
    {
        public static IConveyBuilder AddInfrastructure(this IConveyBuilder builder)
        {
            return builder;
        }

        public static IApplicationBuilder UseInfrastructure(this IApplicationBuilder app)
        {
            return app;
        }
    }
}
