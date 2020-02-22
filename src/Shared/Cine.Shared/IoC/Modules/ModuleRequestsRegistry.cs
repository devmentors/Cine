using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Cine.Shared.IoC.Modules
{
    internal class ModuleRequestsRegistry : IModuleRequestsRegistry
    {
        private readonly IDictionary<string, Func<Task<object>>> _actions;

        public ModuleRequestsRegistry(IDictionary<string, Func<Task<object>>> actions)
            => _actions = actions;

        public bool TryAddAction(string path, Func<Task<object>> action)
            => _actions.TryAdd(path, action);
    }
}
