using System;
using System.Threading.Tasks;

namespace Cine.Shared.IoC.Modules
{
    public interface IModuleRequestMapper
    {
        IModuleRequestMapper Map<TRequest>(string path, Func<TRequest, Task<object>> action)
            where TRequest : class, IModuleRequest;
    }
}
