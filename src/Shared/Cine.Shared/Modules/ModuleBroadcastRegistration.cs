using System;
using System.Threading.Tasks;

namespace Cine.Shared.Modules
{
    internal sealed class ModuleBroadcastRegistration
    {
        public Type ReceiverType { get; set; }
        public Func<IServiceProvider, object, Task> Action { get; set; }

        public string Path => ReceiverType.Name;
    }
}
