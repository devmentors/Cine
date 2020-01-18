using System;
using Cine.Modules.Cinemas.Api.Mongo.Documents;
using Cine.Modules.Cinemas.Api.Services;
using Cine.Modules.Cinemas.Api.Validators;
using Convey;
using Convey.Persistence.MongoDB;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace Cine.Modules.Cinemas.Api
{
    public static class Extensions
    {
        public static IConveyBuilder AddCinemasModule(this IConveyBuilder builder)
        {
            builder.Services.AddSingleton<ICinemaDtoValidator, CinemaDtoValidator>();
            builder.Services.AddSingleton<ICinemasService, CinemasService>();

            return builder
                .AddMongo()
                .AddMongoRepository<CinemaDocument, Guid>("cinemas");
        }

        public static IApplicationBuilder UseCinemasModule(this IApplicationBuilder app)
        {
            return app;
        }
    }
}
