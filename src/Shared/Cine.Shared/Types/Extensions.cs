using System;
using System.Linq;
using Cine.Shared.Modules;
using Convey;
using Convey.CQRS.Events;
using Microsoft.Extensions.DependencyInjection;

namespace Cine.Shared.Types
{
    public static class Extensions
    {
        public static IConveyBuilder AddAppTypesRegistry(this IConveyBuilder builder)
        {
            var types = AppDomain.CurrentDomain
                .GetAssemblies()
                .Where(a => a.FullName.Contains("Cine"))
                .SelectMany(a => a.GetTypes())
                .Where(t => t.IsClass && (typeof(IModuleRequest).IsAssignableFrom(t) || typeof(IEvent).IsAssignableFrom(t)))
                .ToList();

            var registry = new AppTypesRegistry();
            types.ForEach(e => registry.TryAdd(e));

            builder.Services.AddSingleton<IAppTypesRegistry>(registry);
            return builder;
        }
    }
}
