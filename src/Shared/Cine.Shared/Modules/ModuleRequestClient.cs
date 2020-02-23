using System;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Cine.Shared.Modules
{
    internal sealed class ModuleRequestClient : IModuleRequestClient
    {
        private readonly IModuleRequestsRegistry _moduleRequestsRegistry;

        public ModuleRequestClient(IModuleRequestsRegistry moduleRequestsRegistry)
            => _moduleRequestsRegistry = moduleRequestsRegistry;

        public async Task<TResult> GetAsync<TResult>(string path, object moduleRequest) where TResult : class
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
