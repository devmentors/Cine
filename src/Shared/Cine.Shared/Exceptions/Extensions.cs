using System.Collections;
using System.Threading.Tasks;
using Cine.Shared.Exceptions.Mappers;
using Cine.Shared.Exceptions.Middlewares;
using Microsoft.Extensions.DependencyInjection;
using Valit;

namespace Cine.Shared.Exceptions
{
    public static class Extensions
    {
        public static IServiceCollection AddErrorHandling(this IServiceCollection services)
        {
            services.AddTransient<IExceptionCompositionRoot, ExceptionCompositionRoot>();
            services.AddSingleton<IExceptionToResponseMapper, DefaultExceptionToResponseMapper>();

            return services;
        }

        public static IServiceCollection AddExceptionToResponseMapper<TMapper>(this IServiceCollection services)
            where TMapper : class, IExceptionToResponseMapper
        {
            services.AddSingleton<IExceptionToResponseMapper, TMapper>();
            return services;
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
