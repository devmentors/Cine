using System;
using System.Threading.Tasks;

namespace Cine.Shared.Modules
{
    public interface IModuleRequestsRegistry
    {
        ModuleRequestRegistration GetRegistration(string path);
        bool TryAddAction(string path, Type receiverRequestType, Func<object, Task<object>> action);
    }
}
