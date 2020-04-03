using System;
using Cine.Reservations.Core.Repositories;
using Cine.Reservations.Infrastructure.Mongo.Documents;
using Cine.Reservations.Infrastructure.Mongo.Repositories;
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

            builder
                .AddMongo()
                .AddMongoRepository<ReservationDocument, Guid>("reservations");

            return builder;
        }

        public static IApplicationBuilder UseInfrastructure(this IApplicationBuilder app)
        {
            return app;
        }
    }
}
