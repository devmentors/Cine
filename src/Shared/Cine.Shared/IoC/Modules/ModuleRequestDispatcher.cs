using System;
using System.Linq;
using System.Threading.Tasks;
using Cine.Shared.IoC.Registries;
using Newtonsoft.Json;

namespace Cine.Shared.IoC.Modules
{
    internal sealed class ModuleRequestDispatcher : IModuleRequestDispatcher
    {
        private readonly IAppTypesRegistry _registry;
        private readonly IServiceProvider _serviceProvider;

        public ModuleRequestDispatcher(IAppTypesRegistry registry, IServiceProvider serviceProvider)
        {
            _registry = registry;
            _serviceProvider = serviceProvider;
        }

        public async Task<TResult> RequestAsync<TRequest, TResult>(TRequest request) where TRequest : class, IModuleRequest<TResult> where TResult : class
        {
            var moduleRequestTypes = _registry.GetLocalTypes(typeof(TRequest)).ToList();

            if (!moduleRequestTypes.Any())
            {
                throw new InvalidOperationException("No module request type found in any module");
            }
            if (moduleRequestTypes.Count() > 1)
            {
                throw new InvalidOperationException("Module request cannot be processed by more than one module");
            }

            var type = moduleRequestTypes.First();
            var json = JsonConvert.SerializeObject(request);
            var message = JsonConvert.DeserializeObject(json, type);

            var resultType = _registry.GetLocalTypes(typeof(TResult)).First();

            var handlerTypeTemplate = typeof(IModuleRequestHandler<,>);
            var handlerType = handlerTypeTemplate.MakeGenericType(message.GetType(), resultType);

            dynamic handler = _serviceProvider.GetService(handlerType);

            var result = await ((Task<object>)handler.HandleAsync(message));
            var resultJson = JsonConvert.SerializeObject(result);

            return JsonConvert.DeserializeObject<TResult>(resultJson);
        }
    }
}
