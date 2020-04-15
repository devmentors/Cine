using Cine.Modules.Pricing.Api.DTO;
using Cine.Modules.Pricing.Api.Queries;
using Convey.WebApi;
using Microsoft.AspNetCore.Builder;

namespace Cine.Modules.Pricing.Api.Api
{
    public static class Extensions
    {
        public static IApplicationBuilder UsePricingApi(this IApplicationBuilder app)
            => app.UseEndpoints(endpoints => endpoints
                .Get<GetCinemaPricing, PricingDto>("pricing/{cinemaId}", async (query, ctx) =>
                {
                    var dto = new PricingDto {CinemaId = query.CinemaId};
                    await ctx.Response.WriteJsonAsync(dto);
                }));
    }
}
