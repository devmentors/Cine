using Cine.Reservations.Application.Commands;
using Cine.Reservations.Application.DTO;
using Cine.Reservations.Application.Queries;
using Convey.WebApi;
using Convey.WebApi.CQRS;
using Microsoft.AspNetCore.Builder;

namespace Cine.Reservations.Api.Api
{
    public static class Extensions
    {
        public static IApplicationBuilder UseReservationsApi(this IApplicationBuilder app)
            => app.UseDispatcherEndpoints(endpoints => endpoints
                .Get<GetReservation, ReservationDto>("reservations/{id}")
                .Post<CreateReservation>("reservations", (cmd, ctx) =>
                    ctx.Response.Created($"reservations/{cmd.Id}"))
                .Post<CompleteReservation>("reservations/{id}/complete")
                .Post<CancelReservation>("reservations/{id}/cancel"));
    }
}
