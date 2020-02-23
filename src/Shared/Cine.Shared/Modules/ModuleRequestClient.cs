using System;
using System.Linq;
using System.Threading.Tasks;
using Cine.Shared.Types;
using Newtonsoft.Json;

namespace Cine.Shared.Modules
{
    internal sealed class ModuleRequestClient : IModuleRequestClient
    {
        private readonly IAppTypesRegistry _appTypesRegistry;
        private readonly IModuleRequestsRegistry _moduleRequestsRegistry;

        public ModuleRequestClient(IAppTypesRegistry appTypesRegistry, IModuleRequestsRegistry moduleRequestsRegistry)
        {
            _appTypesRegistry = appTypesRegistry;
            _moduleRequestsRegistry = moduleRequestsRegistry;
        }

        public async Task<TResult> GetAsync<TRequest, TResult>(string path, TRequest moduleRequest)
            where TRequest : class, IModuleRequest where TResult : class
        {
            var moduleRequestTypes = _appTypesRegistry.GetLocalTypes(typeof(TRequest))
                .ToList();

            if (!moduleRequestTypes.Any())
            {
                throw new InvalidOperationException("No module request type found in any module");
            }

            if (moduleRequestTypes.Count > 1)
            {
                throw new InvalidOperationException("Module request cannot be processed by more than one module");
            }

            var type = moduleRequestTypes.First();
            var json = JsonConvert.SerializeObject(moduleRequest);
            var message = JsonConvert.DeserializeObject(json, type);

            var action = _moduleRequestsRegistry.GetAction(path);

            if (action is null)
            {
                throw new InvalidOperationException($"No action has been defined for module request: {type.Name}");
            }

            var result = await action((IModuleRequest) message);
            var resultJson = JsonConvert.SerializeObject(result);

            return JsonConvert.DeserializeObject<TResult>(resultJson);
        }
    }
}
