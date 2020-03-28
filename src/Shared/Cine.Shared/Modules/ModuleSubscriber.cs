using System;
using System.Threading.Tasks;

namespace Cine.Shared.Modules
{
    internal sealed class ModuleSubscriber : IModuleSubscriber
    {
        private readonly IModuleRegistry _registry;

        public ModuleSubscriber(IModuleRegistry registry)
            => _registry = registry;

        public IModuleSubscriber Subscribe<TRequest>(string path, Func<IServiceProvider, TRequest, Task<object>> action) where TRequest : class
        {
            if (!_registry.TryAddRequestAction(path, typeof(TRequest), (sp, o) => action(sp, (TRequest)o)))
            {
                throw new Exception();
            }

            return this;
        }
    }
}
