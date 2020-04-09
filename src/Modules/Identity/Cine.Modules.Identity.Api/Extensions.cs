using System;
using Cine.Modules.Identity.Api.Mongo.Documents;
using Cine.Modules.Identity.Api.Options;
using Cine.Modules.Identity.Api.Services;
using Convey;
using Convey.CQRS.Commands;
using Convey.CQRS.Queries;
using Convey.Persistence.MongoDB;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;

namespace Cine.Modules.Identity.Api
{
    public static class Extensions
    {
        public static IConveyBuilder AddIdentityModule(this IConveyBuilder builder)
        {
            var options = builder.GetOptions<IdentityOptions>("identity");

            builder.Services.AddSingleton(options);
            builder.Services.AddTransient<ITokensService, TokensService>();
            builder.Services.AddSingleton<IPasswordsService, PasswordService>();
            builder.Services.AddMemoryCache();

            builder.Services.AddAuthentication(o =>
            {
                o.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                o.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(o =>
            {
                o.RequireHttpsMetadata = false;
                o.SaveToken = true;
                o.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(options.Key),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });

            return builder
                .AddCommandHandlers()
                .AddQueryHandlers()
                .AddInMemoryCommandDispatcher()
                .AddInMemoryQueryDispatcher()
                .AddMongo()
                .AddMongoRepository<UserDocument, Guid>("users");
        }

        public static IApplicationBuilder UseIdentityModule(this IApplicationBuilder app)
        {
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseEndpoints(endpoints => endpoints.MapControllers());
            return app;
        }
    }
}
