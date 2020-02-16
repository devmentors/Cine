using System.Collections.Generic;
using System.Linq;
using Cine.Modules.Schedules.Core.Entities;
using Cine.Modules.Schedules.Core.Types;
using Cine.Modules.Schedules.Core.ValueObjects;

namespace Cine.Modules.Schedules.Application.Commands.WriteModels
{
    public static class Extensions
    {
        public static ScheduleSchemaTimes AsScheduleSchemaTimes(this IEnumerable<ScheduleSchemaTimesWriteModel> times)
        {
            var mappedTimes = times
                .Select(st => (st.AgeRestriction, st.Times.Select(t => new Time(t.Hour, t.Minute))));

            return new ScheduleSchemaTimes(mappedTimes);
        }
    }
}
