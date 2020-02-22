using System;
using System.Threading.Tasks;

namespace Cine.Shared.IoC.Modules
{
    public interface IModuleRequestsRegistry
    {
        bool TryAddAction(string path, Func<Task<object>> action);
    }
}
