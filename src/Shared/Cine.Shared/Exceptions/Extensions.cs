using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cine.Shared.Exceptions.Mappers;
using Cine.Shared.Exceptions.Middlewares;
using Convey;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Valit;

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

        public static void ThrowIfInvalid(this IValitResult result)
        {
            if (result.Succeeded)
            {
                return;
            }

            throw new ValidationException(result.ErrorMessages);
        }

        public static async Task<TResult> ThrowIfNotFoundAsync<TResult>(this Task<TResult> task)
        {
            var result = await task;

            switch (result)
            {
                case null:
                    throw new NotFoundException();
                case ICollection collection when collection.Count is 0:
                    throw new NotFoundException();
                case IEnumerable enumerable when !enumerable.GetEnumerator().MoveNext():
                    throw new NotFoundException();
            }

            return result;
        }
    }
}
