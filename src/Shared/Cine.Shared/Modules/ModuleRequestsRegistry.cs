using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Cine.Shared.Modules
{
    internal class ModuleRequestsRegistry : IModuleRequestsRegistry
    {
        private readonly IDictionary<string, ModuleRequestRegistration> _actions;

        public ModuleRequestsRegistry()
            => _actions = new Dictionary<string, ModuleRequestRegistration>();

        public ModuleRequestRegistration GetRegistration(string path)
            => _actions[path];

        public bool TryAddAction(string path, Type receiverRequestType, Func<object, Task<object>> action)
        {
            var registration = new ModuleRequestRegistration
            {
                ReceiverRequestType = receiverRequestType,
                Action = action
            };

            return _actions.TryAdd(path, registration);
        }
    }
}
