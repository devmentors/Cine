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
using Cine.Shared.Mongo;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace Cine.Modules.Schedules.Infrastructure
{
    public static class Extensions
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddTransient<IHallsRepository, HallsRepository>();
            services.AddTransient<IScheduleSchemasRepository, ScheduleSchemasRepository>();
            services.AddTransient<ISchedulesRepository, SchedulesRepository>();
            services.AddTransient<ISchedulesQueryService, SchedulesQueryService>();
            services.AddTransient<IMoviesApiClient, MoviesApiClient>();
            services.AddSingleton<IEventMapper, EventMapper>();

            return services
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
