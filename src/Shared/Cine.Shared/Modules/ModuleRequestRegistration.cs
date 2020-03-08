using System;
using System.Threading.Tasks;

namespace Cine.Shared.Modules
{
    internal sealed  class ModuleRequestRegistration
    {
        public Type ReceiverType { get; set; }
        public Func<object, Task<object>> Action { get; set; }
    }
}
