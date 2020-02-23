using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;

namespace Cine.Shared.Types
{
    internal sealed class AppTypesRegistry : IAppTypesRegistry
    {
        private readonly ConcurrentDictionary<Type, string> _registry;

        public AppTypesRegistry()
            => _registry = new ConcurrentDictionary<Type, string>();

        public bool TryAdd(Type type)
            => _registry.TryAdd(type, type.Name);

        public IEnumerable<Type> GetLocalTypes(Type type)
            => _registry
                .Where(r => r.Key != type)
                .Where(r => r.Value.Equals(type.Name, StringComparison.InvariantCultureIgnoreCase))
                .Select(r => r.Key);
    }
}
