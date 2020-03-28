using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Cine.Shared.Modules
{
    internal interface IModuleRegistry
    {
        ModuleRequestRegistration GetRequestRegistration(string path);
        IEnumerable<ModuleBroadcastRegistration> GetBroadcastRegistration(string path);
        bool TryAddRequestAction(string path, Type receiverType, Func<IServiceProvider, object, Task<object>> action);
        void AddBroadcastAction(Type receiverType, Func<IServiceProvider, object, Task> action);
    }
}
