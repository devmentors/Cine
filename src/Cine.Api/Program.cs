using System.Threading.Tasks;
using Cine.Modules.Movies.Api;
using Convey;
using Convey.Logging;
using Convey.WebApi;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;

namespace Cine.Api
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
                    .AddWebApi()
                    .AddMoviesModule()
                    .Build())
                .Configure(app => app
                    .UseMoviesModule()
                    .UseRouting()
                    .UseEndpoints(endpoints => endpoints.MapControllers()))
                .UseLogging();
    }
}
