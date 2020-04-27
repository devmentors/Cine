using System;
using Cine.Shared.Kernel.ValueObjects;

namespace Cine.Modules.Schedules.Core.Types
{
    internal static class Extensions
    {
        public static bool CollidesOnPeriod(this Time time, Time timeToCompare, int period)
            => Math.Abs(time.TotalMinutes - timeToCompare.TotalMinutes) <= period;
    }
}
