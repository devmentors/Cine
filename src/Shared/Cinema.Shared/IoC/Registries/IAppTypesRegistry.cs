using System;
using System.Collections.Generic;

namespace Cinema.Shared.IoC.Registries
{
    internal interface IAppTypesRegistry
    {
        bool TryAdd(Type type);
        IEnumerable<Type> GetLocalTypes(Type type);
    }
}
