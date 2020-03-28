using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cine.Shared.Modules
{
    internal class ModuleRegistry : IModuleRegistry
    {
        private readonly IDictionary<string, ModuleRequestRegistration> _requestActions;
        private readonly IList<ModuleBroadcastRegistration> _broadcastActions;

        public ModuleRegistry()
        {
            _broadcastActions = new List<ModuleBroadcastRegistration>();
            _requestActions = new Dictionary<string, ModuleRequestRegistration>();
        }

        public ModuleRequestRegistration GetRequestRegistration(string path)
            => _requestActions[path];

        public IEnumerable<ModuleBroadcastRegistration> GetBroadcastRegistration(string path)
            => _broadcastActions.Where(r => r.Path == path);

        public bool TryAddRequestAction(string path, Type receiverType, Func<IServiceProvider, object, Task<object>> action)
        {
            var registration = new ModuleRequestRegistration
            {
                ReceiverType = receiverType,
                Action = action
            };

            return _requestActions.TryAdd(path, registration);
        }

        public void AddBroadcastAction(Type receiverType, Func<IServiceProvider, object, Task> action)
        {
            var registration = new ModuleBroadcastRegistration
            {
                ReceiverType = receiverType,
                Action = action
            };

            _broadcastActions.Add(registration);
        }
    }
}
