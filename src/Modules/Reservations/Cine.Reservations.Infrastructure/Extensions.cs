using System;
using Cine.Reservations.Core.Repositories;
using Cine.Reservations.Core.Services;
using Cine.Reservations.Core.Validators;
using Cine.Reservations.Infrastructure.Mongo.Documents;
using Cine.Reservations.Infrastructure.Mongo.Repositories;
using Cine.Reservations.Infrastructure.Services;
using Cine.Reservations.Infrastructure.Validators;
using Convey;
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
            builder.Services.AddTransient<IReserveesService, ReserveesService>();
            builder.Services.AddTransient<IReservationSeatsValidator, ReservationSeatsValidator>();

            return builder
                .AddMongo()
                .AddMongoRepository<ReservationDocument, Guid>("reservations");
        }

        public static IApplicationBuilder UseInfrastructure(this IApplicationBuilder app)
        {
            return app;
        }
    }
}
