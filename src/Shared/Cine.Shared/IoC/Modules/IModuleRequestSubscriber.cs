using System;
using System.Threading.Tasks;

namespace Cine.Shared.IoC.Modules
{
    public interface IModuleRequestSubscriber
    {
        IModuleRequestSubscriber Map(string path, Func<Task<object>> action);
    }
}
