using System;
using System.Threading.Tasks;

namespace Cine.Shared.Modules
{
    public class ModuleRequestRegistration
    {
        public Type ReceiverRequestType { get; set; }
        public Func<object, Task<object>> Action { get; set; }
    }
}
