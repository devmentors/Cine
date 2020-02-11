using System.Threading.Tasks;
using Cine.Modules.Cinemas.Api;
using Cine.Modules.Movies.Api;
using Cine.Modules.Schedules.Api;
using Cine.Shared;
using Cine.Shared.Exceptions;
using Cine.Shared.IoC.Dispatchers;
using Cine.Shared.IoC.Modules;
using Convey;
using Convey.Logging;
using Convey.WebApi;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;

namespace Cine.Bootstrapper
{
    public class Program
    {
        public static async Task Main(string[] args)
            => await CreateWebHostBuilder(args)
                .Build()
                .RunAsync();

        public static IWebHostBuilder CreateWebHostBuilder(string[] args)
            => WebHost.CreateDefaultBuilder(args)
                .ConfigureServices(services => services
                    .AddConvey()
                    .AddMoviesModule()
                    .AddCinemasModule()
                    .AddSchedulesModule()
                    .AddSchedulesModule()
                    .AddModuleRequests()
                    .AddWebApi()
                    .AddAppTypesEventDispatcher()
                    .AddErrorHandling()
                    .Build())
                .Configure(app => app
                    .UseMoviesModule()
                    .UseCinemasModule()
                    .UseSchedulesModule()
                    .UseSharedModule()
                    .UseErrorHandling()
                    .UseRouting()
                    .UseEndpoints(endpoints => endpoints.MapControllers()))
                .UseLogging();
    }
}
