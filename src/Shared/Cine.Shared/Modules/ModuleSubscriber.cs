using System;
using System.Threading.Tasks;

namespace Cine.Shared.Modules
{
    internal sealed class ModuleSubscriber : IModuleSubscriber
    {
        private readonly IModuleRegistry _registry;

        public ModuleSubscriber(IModuleRegistry registry)
            => _registry = registry;

        public IModuleSubscriber Subscribe<TRequest>(string path, Func<TRequest, Task<object>> action) where TRequest : class
        {
            if (!_registry.TryAddRequestAction(path, typeof(TRequest), o => action((TRequest)o)))
            {
                throw new Exception();
            }

            return this;
        }
    }
}
