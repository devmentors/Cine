using System;
using System.Threading.Tasks;

namespace Cine.Shared.IoC.Modules
{
    internal sealed class ModuleRequestMapper : IModuleRequestMapper
    {
        private readonly IModuleRequestsRegistry _registry;

        public ModuleRequestMapper(IModuleRequestsRegistry registry)
            => _registry = registry;

        public IModuleRequestMapper Map<TRequest>(string path, Func<TRequest, Task<object>> action) where TRequest : class, IModuleRequest
        {
            if (!_registry.TryAddAction(path, o => action((TRequest)o)))
            {
                throw new Exception();
            }

            return this;
        }
    }
}
