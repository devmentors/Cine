using Microsoft.AspNetCore.Builder;

namespace Cine.Reservations.Api.Api
{
    public static class Extensions
    {
        public static IApplicationBuilder UseReservationsApi(this IApplicationBuilder app)
        {
            return app;
        }
    }
}
