using System;
using System.Linq;
using Microsoft.Extensions.DependencyInjection;

namespace Cine.Shared.Exceptions.Mappers
{
    internal sealed class ExceptionCompositionRoot : IExceptionCompositionRoot
    {
        private readonly IServiceScopeFactory _serviceScopeFactory;

        public ExceptionCompositionRoot(IServiceScopeFactory serviceScopeFactory)
            => _serviceScopeFactory = serviceScopeFactory;

        public (int httpStatusCode, string[] errorCodes)? Map(Exception exception)
        {
            using var scope = _serviceScopeFactory.CreateScope();
            var mappers = scope.ServiceProvider.GetServices<IExceptionToResponseMapper>();

            return mappers
                .Select(m => m.Map(exception))
                .SingleOrDefault(r => r is {});
        }
    }
}
