using System;
using System.Linq;
using Cine.Shared.IoC.Modules;
using Cine.Shared.IoC.Registries;
using Convey;
using Microsoft.Extensions.DependencyInjection;

namespace Cine.Shared.IoC
{
    public static class Extensions
    {
        public static IConveyBuilder AddModuleRequests(this IConveyBuilder builder)
        {
            builder.Services.Scan(s => s.FromAssemblies(AppDomain.CurrentDomain.GetAssemblies())
                .AddClasses(c => c.AssignableTo(typeof(IModuleRequestHandler<,>)))
                .AsImplementedInterfaces()
                .WithTransientLifetime());

            builder.RegisterModuleRequestsTypes();
            builder.Services.AddTransient<IModuleRequestDispatcher, ModuleRequestDispatcher>();

            return builder;
        }

        private static void RegisterModuleRequestsTypes(this IConveyBuilder builder)
        {
            var requests = AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(a => a.GetTypes())
                .Where(t => t.IsClass && typeof(IModuleRequest<>).IsAssignableFrom(t))
                .ToList();

            var registry = new AppTypesRegistry();

            foreach (var request in requests)
            {
                var resultType = request.GetGenericArguments().First();
                registry.TryAdd(request);
                registry.TryAdd(resultType);
            }

            builder.Services.AddSingleton<IAppTypesRegistry>(registry);
        }
    }
}
