using System;
using Microsoft.Extensions.DependencyInjection;

namespace Cine.Shared.Exceptions.Mappers
{
    internal sealed class ExceptionCompositionRoot : IExceptionCompositionRoot
    {
        private readonly IServiceProvider _serviceProvider;

        public ExceptionCompositionRoot(IServiceProvider serviceProvider)
            => _serviceProvider = serviceProvider;

        public (int httpStatusCode, string errorCode)? Map(Exception exception)
        {
            var mappers = _serviceProvider.GetServices<IExceptionToResponseMapper>();

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
