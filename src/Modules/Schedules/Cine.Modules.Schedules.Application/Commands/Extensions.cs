using System.Collections.Generic;
using System.Linq;
using Cine.Modules.Schedules.Application.Commands.WriteModels;
using Cine.Modules.Schedules.Core.Entities;
using Cine.Modules.Schedules.Core.ValueObjects;

namespace Cine.Modules.Schedules.Application.Commands
{
    public static class Extensions
    {
        public static ScheduleSchemaTimes AsScheduleSchemaTimes(
            this IEnumerable<(int ageRestriction, IEnumerable<TimeWriteModel> times)> times)
        {
            var mappedTimes = times
                .Select(st => (st.ageRestriction, st.times.Select(t => new Time(t.Hour, t.Minute))));

            return new ScheduleSchemaTimes(mappedTimes);
        }
    }
}
