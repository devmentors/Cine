using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Cine.Shared.Modules
{
    internal class ModuleRequestsRegistry : IModuleRequestsRegistry
    {
        private readonly IDictionary<string, Func<IModuleRequest, Task<object>>> _actions;

        public ModuleRequestsRegistry()
            => _actions = new Dictionary<string, Func<IModuleRequest, Task<object>>>();

        public Func<IModuleRequest, Task<object>> GetAction(string path)
            => _actions[path];


        public bool TryAddAction(string path, Func<IModuleRequest, Task<object>> action)
            => _actions.TryAdd(path, action);
    }
}
