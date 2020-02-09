using Cine.Shared.Exceptions.Mappers;
using Cine.Shared.Exceptions.Middlewares;
using Convey;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace Cine.Shared.Exceptions
{
    public static class Extensions
    {
        public static IConveyBuilder AddErrorHandling(this IConveyBuilder builder)
        {
            builder.Services.AddTransient<IExceptionCompositionRoot, ExceptionCompositionRoot>();
            builder.Services.AddSingleton<IExceptionToResponseMapper, DefaultExceptionToResponseMapper>();

            return builder;
        }

        public static IConveyBuilder AddExceptionToResponseMapper<TMapper>(this IConveyBuilder builder)
            where TMapper : class, IExceptionToResponseMapper
        {
            builder.Services.AddSingleton<IExceptionToResponseMapper, TMapper>();
            return builder;
        }

        public static IApplicationBuilder UseErrorHandling(this IApplicationBuilder app)
        {
            app.UseMiddleware<ExceptionMiddleware>();
            return app;
        }
    }
}
