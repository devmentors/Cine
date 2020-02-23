using System;
using System.Collections.Generic;

namespace Cine.Shared.IoC.Types
{
    internal interface IAppTypesRegistry
    {
        bool TryAdd(Type type);
        IEnumerable<Type> GetLocalTypes(Type type);
    }
}
