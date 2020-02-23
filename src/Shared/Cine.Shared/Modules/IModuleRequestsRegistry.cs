using System;
using System.Threading.Tasks;

namespace Cine.Shared.Modules
{
    public interface IModuleRequestsRegistry
    {
        Func<IModuleRequest, Task<object>> GetAction(string path);
        bool TryAddAction(string path, Func<IModuleRequest, Task<object>> action);
    }
}
