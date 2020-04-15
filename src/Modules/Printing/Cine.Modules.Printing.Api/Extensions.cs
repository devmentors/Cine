using Convey;
using Microsoft.AspNetCore.Builder;

namespace Cine.Modules.Printing.Api
{
    public static class Extensions
    {
        public static IConveyBuilder AddPrintingModule(this IConveyBuilder builder)
            => builder;

        public static IApplicationBuilder UsePrintingModule(this IApplicationBuilder app)
            => app;
    }
}
