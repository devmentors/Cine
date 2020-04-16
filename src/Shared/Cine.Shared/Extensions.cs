using Cine.Shared.Commands;
using Cine.Shared.Events;
using Cine.Shared.Exceptions;
using Cine.Shared.MessageBrokers;
using Cine.Shared.Modules;
using Cine.Shared.Queries;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Cine.Shared
{
    public static class Extensions
    {
        public static IServiceCollection AddSharedModule(this IServiceCollection services)
        {
            services
                .AddInMemoryCommandDispatcher()
                .AddInMemoryEventDispatcher()
                .AddInMemoryQueryDispatcher()
                .AddCommandHandlers()
                .AddEventHandlers()
                .AddQueryHandlers()
                .AddModuleRequests()
                .AddErrorHandling();

            services.AddTransient<IMessageBroker, MessageBroker>();
            services.AddTransient<IEventMapperCompositionRoot, EventMapperCompositionRoot>();
            services.AddTransient<IEventProcessor, EventProcessor>();

            return services;
        }

        public static IApplicationBuilder UseSharedModule(this IApplicationBuilder app)
        {
            app.UseErrorHandling();
            return app;
        }

        internal static TModel GetOptions<TModel>(this IServiceCollection services, string settingsSectionName)
            where TModel : new()
        {
            using var serviceProvider = services.BuildServiceProvider();
            var configuration = serviceProvider.GetService<IConfiguration>();
            var model = new TModel();
            configuration.GetSection(settingsSectionName).Bind(model);
            return model;
        }

    }
}
