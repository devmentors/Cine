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
            where TRequest : class where TResult : class
        {
            var registration = _moduleRequestsRegistry.GetRegistration(path);

            if (registration is null)
            {
                throw new InvalidOperationException($"No action has been defined for path: {path}");
            }

            var action = registration.Action;
            var requestJson = JsonConvert.SerializeObject(moduleRequest);
            var receiverRequest = JsonConvert.DeserializeObject(requestJson, registration.ReceiverRequestType);

            var result = await action(receiverRequest);
            var resultJson = JsonConvert.SerializeObject(result);

            return JsonConvert.DeserializeObject<TResult>(resultJson);
        }
    }
}
