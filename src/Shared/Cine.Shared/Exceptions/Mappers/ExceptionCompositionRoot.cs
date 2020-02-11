using System;
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

            foreach (var mapper in mappers)
            {
                var response = mapper.Map(exception);
                if (response is {})
                {
                    return response;
                }
            }
            return null;
        }
    }
}
