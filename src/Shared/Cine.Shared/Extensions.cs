using Cine.Shared.Events;
using Cine.Shared.MessageBrokers;

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
