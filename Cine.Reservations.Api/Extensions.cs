using Cine.Reservations.Api.Api;
using Cine.Reservations.Application;
using Cine.Reservations.Infrastructure;
using Convey;
using Microsoft.AspNetCore.Builder;

namespace Cine.Reservations.Api
{
    public static class Extensions
    {
        public static IConveyBuilder AddSchedulesModule(this IConveyBuilder builder)
            => builder.AddInfrastructure().AddApplication();

        public static IApplicationBuilder UseSchedulesModule(this IApplicationBuilder app)
            => app
                .UseReservationsApi()
                .UseInfrastructure()
                .UseApplication();
    }
}
