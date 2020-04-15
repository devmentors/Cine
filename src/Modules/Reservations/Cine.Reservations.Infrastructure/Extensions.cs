using System;
using Cine.Reservations.Application.DTO;
using Cine.Reservations.Application.Queries;
using Cine.Reservations.Application.Services;
using Cine.Reservations.Core.Repositories;
using Cine.Reservations.Core.Services;
using Cine.Reservations.Core.Validators;
using Cine.Reservations.Infrastructure.Mongo.Documents;
using Cine.Reservations.Infrastructure.Mongo.QueryServices;
using Cine.Reservations.Infrastructure.Mongo.Repositories;
using Cine.Reservations.Infrastructure.Mongo.Validators;
using Cine.Reservations.Infrastructure.Services;
using Cine.Shared.Events;
using Cine.Shared.Modules;
using Convey;
using Convey.CQRS.Queries;
using Convey.Persistence.MongoDB;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace Cine.Reservations.Infrastructure
{
    public static class Extensions
    {
        public static IConveyBuilder AddInfrastructure(this IConveyBuilder builder)
        {
            builder.Services.AddTransient<IReservationsRepository, ReservationsRepository>();
            builder.Services.AddTransient<IReservationsQueryService, ReservationsQueryService>();
            builder.Services.AddTransient<IReserveesProvider, ReserveesProvider>();
            builder.Services.AddTransient<IReservationSeatsValidator, ReservationSeatsValidator>();
            builder.Services.AddSingleton<IEventMapper, EventMapper>();

            return builder
                .AddMongo()
                .AddMongoRepository<ReservationDocument, Guid>("reservations");
        }

        public static IApplicationBuilder UseInfrastructure(this IApplicationBuilder app)
        {
            app
                .UseModuleRequests()
                .Subscribe<GetReservation>("modules/reservations/details", async (sp, query) =>
                {
                    var handler = sp.GetService<IQueryHandler<GetReservation, ReservationDto>>();
                    return await handler.HandleAsync(query);
                });

            return app;
        }
    }
}
