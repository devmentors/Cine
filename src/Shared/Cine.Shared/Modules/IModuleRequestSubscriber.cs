using System;
using System.Threading.Tasks;

namespace Cine.Shared.Modules
{
    public interface IModuleRequestSubscriber
    {
        IModuleRequestSubscriber Subscribe<TRequest>(string path, Func<TRequest, Task<object>> action)
            where TRequest : class;
    }
}
