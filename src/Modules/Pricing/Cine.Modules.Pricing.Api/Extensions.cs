using Cine.Modules.Pricing.Api.Api;
using Convey;
using Microsoft.AspNetCore.Builder;

namespace Cine.Modules.Pricing.Api
{
    public static class Extensions
    {
        public static IConveyBuilder AddPricingModule(this IConveyBuilder builder)
            => builder;

        public static IApplicationBuilder UsePricingModule(this IApplicationBuilder app)
        {
            app.UsePricingApi();
            return app;
        }
    }
}
