using System.Collections;
using System.Collections.Generic;
using Cine.Modules.Schedules.Core.ValueObjects;

namespace Cine.Modules.Schedules.Core.Entities
{
    public sealed class ScheduleTemplateTimes : IEnumerable<(int ageRestriction, IEnumerable<ScheduleTime> scheduleTimes)>
    {
        private readonly IEnumerable<(int ageRestriction, IEnumerable<ScheduleTime> scheduleTimes)> _times;

        public ScheduleTemplateTimes(IEnumerable<(int ageRestriction, IEnumerable<ScheduleTime> scheduleTimes)> times)
            => _times = times;

        public IEnumerator<(int ageRestriction, IEnumerable<ScheduleTime> scheduleTimes)> GetEnumerator()
            => _times.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator()
            => _times.GetEnumerator();
    }
}
