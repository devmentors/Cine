using Cine.Reservations.Core.Factories;
using Convey;
using Convey.CQRS.Commands;
using Convey.CQRS.Events;
using Convey.CQRS.Queries;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace Cine.Reservations.Application
{
    public static class Extensions
    {
        public static IConveyBuilder AddApplication(this IConveyBuilder builder)
        {
            builder.Services.AddTransient<IReservationsFactory, ReservationsFactory>();

            return builder
                .AddCommandHandlers()
                .AddEventHandlers()
                .AddQueryHandlers()
                .AddInMemoryCommandDispatcher()
                .AddInMemoryEventDispatcher()
                .AddInMemoryQueryDispatcher();
        }

        public static IApplicationBuilder UseApplication(this IApplicationBuilder app)
        {
            return app;
        }
    }
}
