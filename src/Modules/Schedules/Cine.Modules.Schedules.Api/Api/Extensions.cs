using Cine.Modules.Schedules.Application.Commands;
using Cine.Modules.Schedules.Application.DTO;
using Cine.Modules.Schedules.Application.Queries;
using Convey.WebApi;
using Convey.WebApi.CQRS;
using Microsoft.AspNetCore.Builder;

namespace Cine.Modules.Schedules.Api.Api
{
    public static class Extensions
    {
        public static IApplicationBuilder UseSchedulesApi(this IApplicationBuilder app)
            => app.UseDispatcherEndpoints(endpoints => endpoints
            .Get<GetWeeklySchedule, ScheduleDto>("schedules/weekly")
            .Post<CreateScheduleSchema>("schedules/schema", afterDispatch: (cmd, ctx)
                => ctx.Response.Created($"schedules/schema/{cmd.Id}"))
            .Post<GenerateSchedule>("schedules/generate", afterDispatch: (cmd, ctx)
                => ctx.Response.Created($"schedules/{cmd.Id}")));
    }
}
