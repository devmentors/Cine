using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cine.Shared.Modules
{
    internal sealed class ModuleClient : IModuleClient
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly IModuleRegistry _moduleRegistry;

        public ModuleClient(IServiceProvider serviceProvider, IModuleRegistry moduleRegistry)
        {
            _serviceProvider = serviceProvider;
            _moduleRegistry = moduleRegistry;
        }

        public async Task<TResult> GetAsync<TResult>(string path, object moduleRequest) where TResult : class
        {
            var registration = _moduleRegistry.GetRequestRegistration(path);

            if (registration is null)
            {
                throw new InvalidOperationException($"No action has been defined for path: {path}");
            }

            var action = registration.Action;
            var receiverRequest = TranslateType(moduleRequest, registration.ReceiverType);

            var result = await action(_serviceProvider, receiverRequest);
            var resultJson = JsonConvert.SerializeObject(result);

            return JsonConvert.DeserializeObject<TResult>(resultJson);
        }

        public async Task PublishAsync(object moduleBroadcast)
        {
            var tasks = new List<Task>();
            var path = moduleBroadcast.GetType().Name;
            var registrations = _moduleRegistry
                .GetBroadcastRegistration(path)
                .Where(r => r.ReceiverType != moduleBroadcast.GetType());

            foreach (var registration in registrations)
            {
                var action = registration.Action;
                var receiverBroadcast = TranslateType(moduleBroadcast, registration.ReceiverType);
                tasks.Add(action(_serviceProvider, receiverBroadcast));
            }

            await Task.WhenAll(tasks);
        }

        private static object TranslateType(object @object, Type type)
        {
            var json = JsonConvert.SerializeObject(@object);
            var receiverType = JsonConvert.DeserializeObject(json, type);
            return receiverType;
        }
    }
}
