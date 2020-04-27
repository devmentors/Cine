using System;
using Cine.Shared.BuildingBlocks;

namespace Cine.Shared.Kernel.ValueObjects
{
    public sealed class Time : ValueObject
    {
        public int Hour { get; }
        public int Minute { get; }
        public int TotalMinutes => 60 * Hour + Minute;

        public Time(int hour, int minute)
        {
            Hour = hour;
            Minute = minute;
        }

        public bool CollidesOnPeriod(Time time, int period)
            => Math.Abs(TotalMinutes - time.TotalMinutes) <= period;

        public override string ToString()
            => $"{Hour}:{Minute}";
    }
}
