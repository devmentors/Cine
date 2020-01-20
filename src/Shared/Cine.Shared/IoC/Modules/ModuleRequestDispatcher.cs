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

        private const string HandlerMethodName = nameof(IModuleRequestHandler<IModuleRequest<object>, object>.HandleAsync);

        public ModuleRequestDispatcher(IAppTypesRegistry registry, IServiceProvider serviceProvider)
        {
            _registry = registry;
            _serviceProvider = serviceProvider;
        }

        public async Task<TResult> RequestAsync<TRequest, TResult>(TRequest request) where TRequest : class, IModuleRequest<TResult> where TResult : class
        {
            var moduleRequestTypes = _registry.GetLocalTypes(typeof(TRequest))
                .Where(t => t.Assembly != typeof(TRequest).Assembly)
                .ToList();

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

            var handler = _serviceProvider.GetService(handlerType);

            var task = (Task) handler
                .GetType()
                .GetMethod(HandlerMethodName)
                ?.Invoke(handler, new[] {message});

            if (task is null)
            {
                throw new InvalidOperationException($"{HandlerMethodName} not present in {handler.GetType().Name}");
            }

            await task;
            var result = (object) ((dynamic) task).Result;

            var resultJson = JsonConvert.SerializeObject(result);
            return JsonConvert.DeserializeObject<TResult>(resultJson);
        }
    }
}
