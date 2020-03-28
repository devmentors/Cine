using System;
using System.Threading.Tasks;

namespace Cine.Shared.Modules
{
    public interface IModuleSubscriber
    {
        IModuleSubscriber Subscribe<TRequest>(string path, Func<IServiceProvider, TRequest, Task<object>> action)
            where TRequest : class;
    }
}
