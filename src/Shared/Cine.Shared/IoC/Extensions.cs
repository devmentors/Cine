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
                .Where(a => a.FullName.Contains("Cine"))
                .SelectMany(a => a.GetTypes())
                .Where(t => t.IsClass && t.IsAssignableToOpenGeneric(typeof(IModuleRequest<>)))
                .ToList();

            var registry = new AppTypesRegistry();

            foreach (var request in requests)
            {
                var resultType = request
                    .GetInterfaces()
                    .FirstOrDefault()
                    ?.GetGenericArguments()
                    .First();

                registry.TryAdd(request);
                registry.TryAdd(resultType);
            }

            builder.Services.AddSingleton<IAppTypesRegistry>(registry);
        }

        private static bool IsAssignableToOpenGeneric(this Type givenType, Type genericType) {
            return givenType
                .GetInterfaces()
                .Where(it => it.IsGenericType)
                .Any(it => it.GetGenericTypeDefinition() == genericType);
        }
    }
}
