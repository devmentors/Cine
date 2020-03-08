using Cine.Shared.Events;
using Cine.Shared.Exceptions;
using Cine.Shared.MessageBrokers;
using Cine.Shared.Modules;
using Convey;
using Convey.CQRS.Events;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace Cine.Shared
{
    public static class Extensions
    {
        public static IConveyBuilder AddSharedModule(this IConveyBuilder builder)
        {
            builder
                .AddInMemoryEventDispatcher()
                .AddModuleRequests()
                .AddErrorHandling();

            builder.Services.AddTransient<IMessageBroker, MessageBroker>();
            builder.Services.AddTransient<IEventMapperCompositionRoot, EventMapperCompositionRoot>();
            builder.Services.AddTransient<IEventProcessor, EventProcessor>();

            return builder;
        }

        public static IApplicationBuilder UseSharedModule(this IApplicationBuilder app)
        {
            app.UseErrorHandling();
            return app;
        }
    }
}
