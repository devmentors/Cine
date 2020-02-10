using System;
using Cine.Modules.Movies.Api.Mongo.Documents;
using Cine.Modules.Movies.Api.Services;
using Cine.Modules.Movies.Api.Validators;
using Convey;
using Convey.Persistence.MongoDB;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace Cine.Modules.Movies.Api
{
    public static class Extensions
    {
        public static IConveyBuilder AddMoviesModule(this IConveyBuilder builder)
        {
            builder.Services.AddSingleton<IMovieDtoValidator, MovieDtoValidator>();
            builder.Services.AddSingleton<IMoviesService, MoviesService>();
            builder.Services.AddControllers().AddNewtonsoftJson();

            return builder
                .AddMongo()
                .AddMongoRepository<MovieDocument, Guid>("movies");
        }

        public static IApplicationBuilder UseMoviesModule(this IApplicationBuilder app)
        {
            return app;
        }
    }
}
