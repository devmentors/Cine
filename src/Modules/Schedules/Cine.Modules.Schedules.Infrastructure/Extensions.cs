using System;
using Cine.Modules.Schedules.Application;
using Cine.Modules.Schedules.Core.Repositories;
using Cine.Modules.Schedules.Infrastructure.Mongo.Documents;
using Cine.Modules.Schedules.Infrastructure.Mongo.Repositories;
using Convey;
using Convey.Persistence.MongoDB;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace Cine.Modules.Schedules.Infrastructure
{
    public static class Extensions
    {
        public static IConveyBuilder AddSchedulesModule(this IConveyBuilder builder)
            => builder.AddInfrastructure().AddApplication();

        public static IApplicationBuilder UseSchedulesModule(this IApplicationBuilder app)
            => app.UseInfrastructure().UseApplication();

        private static IConveyBuilder AddInfrastructure(this IConveyBuilder builder)
        {
            builder.Services.AddTransient<IHallsRepository, HallsRepository>();
            builder.Services.AddTransient<IScheduleSchemasRepository, ScheduleSchemasRepository>();
            builder.Services.AddTransient<ISchedulesRepository, SchedulesRepository>();

            return builder
                .AddMongo()
                .AddMongoRepository<HallDocument, Guid>("schedules_halls");;
        }

        private static IApplicationBuilder UseInfrastructure(this IApplicationBuilder app)
        {
            return app;
        }
    }
}
