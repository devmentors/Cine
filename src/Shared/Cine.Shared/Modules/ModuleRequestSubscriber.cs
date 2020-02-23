using System;
using System.Threading.Tasks;

namespace Cine.Shared.Modules
{
    internal sealed class ModuleRequestSubscriber : IModuleRequestSubscriber
    {
        private readonly IModuleRequestsRegistry _registry;

        public ModuleRequestSubscriber(IModuleRequestsRegistry registry)
            => _registry = registry;

        public IModuleRequestSubscriber Subscribe<TRequest>(string path, Func<TRequest, Task<object>> action) where TRequest : class
        {
            if (!_registry.TryAddAction(path, typeof(TRequest), o => action((TRequest)o)))
            {
                throw new Exception();
            }

            return this;
        }
    }
}
