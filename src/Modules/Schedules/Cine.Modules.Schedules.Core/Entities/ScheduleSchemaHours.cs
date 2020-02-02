using System.Collections;
using System.Collections.Generic;
using Cine.Modules.Schedules.Core.ValueObjects;

namespace Cine.Modules.Schedules.Core.Entities
{
    public sealed class ScheduleSchemaHours : IEnumerable<(int ageRestriction, IEnumerable<ScheduleTime> scheduleTimes)>
    {
        private readonly IEnumerable<(int ageRestriction, IEnumerable<ScheduleTime> scheduleTimes)> _hours;

        public ScheduleSchemaHours(IEnumerable<(int ageRestriction, IEnumerable<ScheduleTime> scheduleTimes)> hours)
            => _hours = hours;

        public IEnumerator<(int ageRestriction, IEnumerable<ScheduleTime> scheduleTimes)> GetEnumerator()
            => _hours.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator()
            => _hours.GetEnumerator();
    }
}
