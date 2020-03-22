using System;
using Cine.Modules.Schedules.Application.Services;
using Cine.Modules.Schedules.Application.Services.Clients;
using Cine.Modules.Schedules.Core.Repositories;
using Cine.Modules.Schedules.Infrastructure.Mongo.Documents;
using Cine.Modules.Schedules.Infrastructure.Mongo.QueryServices;
using Cine.Modules.Schedules.Infrastructure.Mongo.Repositories;
using Cine.Modules.Schedules.Infrastructure.Services;
using Cine.Modules.Schedules.Infrastructure.Services.Clients;
using Cine.Shared.Events;
using Convey;
using Convey.Persistence.MongoDB;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace Cine.Modules.Schedules.Infrastructure
{
    public static class Extensions
    {
        public static IConveyBuilder AddInfrastructure(this IConveyBuilder builder)
        {
            builder.Services.AddTransient<IHallsRepository, HallsRepository>();
            builder.Services.AddTransient<IScheduleSchemasRepository, ScheduleSchemasRepository>();
            builder.Services.AddTransient<ISchedulesRepository, SchedulesRepository>();
            builder.Services.AddTransient<ISchedulesQueryService, SchedulesQueryService>();
            builder.Services.AddTransient<IMoviesApiClient, MoviesApiClient>();
            builder.Services.AddSingleton<IEventMapper, EventMapper>();

            return builder
                .AddMongo()
                .AddMongoRepository<HallDocument, Guid>("schedules_halls")
                .AddMongoRepository<ScheduleSchemaDocument, Guid>("schedulesSchemas")
                .AddMongoRepository<ScheduleDocument, Guid>("schedules");
        }

        public static IApplicationBuilder UseInfrastructure(this IApplicationBuilder app)
        {
            return app;
        }
    }
}
