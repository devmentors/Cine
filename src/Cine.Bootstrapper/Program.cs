using System.Threading.Tasks;
using Cine.Modules.Cinemas.Api;
using Cine.Modules.Identity.Api;
using Cine.Modules.Movies.Api;
using Cine.Modules.Pricing.Api;
using Cine.Modules.Pricing.Api.Api;
using Cine.Modules.Printing.Api;
using Cine.Modules.Schedules.Api;
using Cine.Reservations.Api;
using Cine.Shared;
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
                    .AddIdentityModule()
                    .AddMoviesModule()
                    .AddCinemasModule()
                    .AddSchedulesModule()
                    .AddPricingModule()
                    .AddPrintingModule()
                    .AddReservationsModule()
                    .AddSharedModule()
                    .AddWebApi()
                    .Build())
                .Configure(app => app
                    .UseSharedModule()
                    .UseIdentityModule()
                    .UseMoviesModule()
                    .UseCinemasModule()
                    .UseSchedulesModule()
                    .UsePricingModule()
                    .UsePrintingModule()
                    .UseReservationsModule())
                .UseLogging();
    }
}
