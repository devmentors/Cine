using System;
using System.Linq;
using Cine.Shared.IoC.Registries;
using Convey;
using Convey.CQRS.Events;
using Microsoft.Extensions.DependencyInjection;

namespace Cine.Shared.IoC.Dispatchers
{
    public static class Extensions
    {
        public static IConveyBuilder AddAppTypesEventDispatcher(this IConveyBuilder builder)
        {
            builder.AddInMemoryEventDispatcher();
            builder.Services.Decorate<IEventDispatcher, AppTypesEventDispatcherDecorator>();

            var events = AppDomain.CurrentDomain.GetAssemblies()
                .Where(a => a.FullName.Contains("Cine"))
                .SelectMany(a => a.GetTypes())
                .Where(t => t.IsClass && typeof(IEvent).IsAssignableFrom(t))
                .ToList();

            using var serviceProvider = builder.Services.BuildServiceProvider();

            var registry = serviceProvider.GetService<IAppTypesRegistry>();
            events.ForEach(e => registry.TryAdd(e));

            return builder;
        }
    }
}
