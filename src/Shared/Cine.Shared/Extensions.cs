using Cine.Shared.Events;
using Cine.Shared.MessageBrokers;
using Convey;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace Cine.Shared
{
    public static class Extensions
    {
        public static IConveyBuilder AddSharedModule(this IConveyBuilder builder)
        {
            builder.Services.AddTransient<IMessageBroker, MessageBroker>();
            builder.Services.AddTransient<IEventProcessor, EventProcessor>();
            return builder;
        }

        public static IApplicationBuilder UseSharedModule(this IApplicationBuilder app)
        {
            return app;
        }
    }
}
