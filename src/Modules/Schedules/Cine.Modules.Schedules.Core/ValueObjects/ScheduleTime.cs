using Cine.Modules.Schedules.Core.Aggregates;
using Cine.Shared.BuildingBlocks;

namespace Cine.Modules.Schedules.Core.ValueObjects
{
    public sealed class ScheduleTime : ValueObject
    {
        public int Hour { get; }
        public int Minute { get; }

        public ScheduleTime(int hour, int minute)
        {
            Hour = hour;
            Minute = minute;
        }

        public bool CollidesOnPeriod(ScheduleTime time, int hoursPeriod)
            => time.Hour - hoursPeriod < Hour || time.Hour + hoursPeriod > Hour;

        public override string ToString()
            => $"{Hour}:{Minute}";
    }
}
