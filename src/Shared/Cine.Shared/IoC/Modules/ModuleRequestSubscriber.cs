using System;
using System.Threading.Tasks;

namespace Cine.Shared.IoC.Modules
{
    internal sealed class ModuleRequestSubscriber : IModuleRequestSubscriber
    {
        private readonly IModuleRequestsRegistry _registry;

        public ModuleRequestSubscriber(IModuleRequestsRegistry registry)
            => _registry = registry;

        public IModuleRequestSubscriber Map(string path, Func<Task<object>> action)
        {
            if (!_registry.TryAddAction(path, action))
            {
                throw new Exception();
            }

            return this;
        }
    }
}
