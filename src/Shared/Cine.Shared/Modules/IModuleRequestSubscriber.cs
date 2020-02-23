using System;
using System.Threading.Tasks;

namespace Cine.Shared.Modules
{
    public interface IModuleRequestSubscriber
    {
        IModuleRequestSubscriber Map<TRequest>(string path, Func<TRequest, Task<object>> action)
            where TRequest : class;
    }
}
