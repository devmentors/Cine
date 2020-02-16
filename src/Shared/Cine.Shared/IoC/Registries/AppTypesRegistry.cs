using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;

namespace Cine.Shared.IoC.Registries
{
    internal sealed class AppTypesRegistry : IAppTypesRegistry
    {
        private readonly ConcurrentDictionary<string, Type> _registry;

        public AppTypesRegistry()
            => _registry = new ConcurrentDictionary<string, Type>();

        public bool TryAdd(Type type)
            => _registry.TryAdd(type.Name, type);

        public bool Contains(Type type)
            => _registry.ContainsKey(type.Name);

        public IEnumerable<Type> GetLocalTypes(Type type)
            => _registry
                .Where(r => r.Value != type)
                .Where(r => r.Key.Equals(type.Name, StringComparison.InvariantCultureIgnoreCase))
                .Select(r => r.Value);
    }
}
