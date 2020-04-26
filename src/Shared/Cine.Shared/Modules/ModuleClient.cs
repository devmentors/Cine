using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace Cine.Shared.Modules
{
    internal sealed class ModuleClient : IModuleClient
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly IModuleRegistry _moduleRegistry;
        private readonly ILogger<IModuleClient> _logger;

        public ModuleClient(IServiceProvider serviceProvider, IModuleRegistry moduleRegistry, ILogger<IModuleClient> logger)
        {
            _serviceProvider = serviceProvider;
            _moduleRegistry = moduleRegistry;
            _logger = logger;
        }

        public async Task<TResult> GetAsync<TResult>(string path, object moduleRequest) where TResult : class
        {
            var registration = _moduleRegistry.GetRequestRegistration(path);

            if (registration is null)
            {
                throw new InvalidOperationException($"No action has been defined for path: {path}");
            }

            var moduleRequestType = moduleRequest.GetType();
            _logger.LogTrace($"Getting data from path {path} using module request of type " +
                             $"{{{moduleRequestType.Name}}} from module {moduleRequestType.Assembly.FullName}...");

            var action = registration.Action;
            var receiverRequest = TranslateType(moduleRequest, registration.ReceiverType);

            _logger.LogTrace($"Translated module request {moduleRequestType.Name} to {registration.ReceiverType.Name}");

            var result = await action(_serviceProvider, receiverRequest);
            var resultJson = JsonConvert.SerializeObject(result);

            _logger.LogTrace($"Returning data from path {path} of type {typeof(TResult).Name}");

            return JsonConvert.DeserializeObject<TResult>(resultJson);
        }

        public async Task PublishAsync(object moduleBroadcast)
        {
            var tasks = new List<Task>();
            var path = moduleBroadcast.GetType().Name;
            var registrations = _moduleRegistry
                .GetBroadcastRegistration(path)
                .Where(r => r.ReceiverType != moduleBroadcast.GetType());

            _logger.LogTrace($"Publishing message of type {moduleBroadcast.GetType().Name} to " +
                             $"{registrations.Count()} module receivers");

            foreach (var registration in registrations)
            {
                var action = registration.Action;
                var receiverBroadcast = TranslateType(moduleBroadcast, registration.ReceiverType);
                tasks.Add(action(_serviceProvider, receiverBroadcast));
            }
            await Task.WhenAll(tasks);

            _logger.LogTrace($"Published message of type {moduleBroadcast.GetType().Name} to " +
                             $"{registrations.Count()} module receivers");
        }

        private static object TranslateType(object @object, Type type)
        {
            var json = JsonConvert.SerializeObject(@object);
            var receiverType = JsonConvert.DeserializeObject(json, type);
            return receiverType;
        }
    }
}
