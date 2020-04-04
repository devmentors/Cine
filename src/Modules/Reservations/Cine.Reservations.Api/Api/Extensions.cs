using Cine.Reservations.Application.Commands;
using Convey.WebApi;
using Convey.WebApi.CQRS;
using Microsoft.AspNetCore.Builder;

namespace Cine.Reservations.Api.Api
{
    public static class Extensions
    {
        public static IApplicationBuilder UseReservationsApi(this IApplicationBuilder app)
            => app.UseDispatcherEndpoints(endpoints => endpoints
                .Post<CreateReservation>("reservations", (cmd, ctx) =>
                    ctx.Response.Created($"reservations/{cmd.Id}")));
    }
}
