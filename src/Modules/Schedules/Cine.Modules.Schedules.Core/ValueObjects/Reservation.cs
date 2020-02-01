using System;
using Cine.Shared.BuildingBlocks;

namespace Cine.Modules.Schedules.Core.ValueObjects
{
    public sealed class Reservation : ValueObject
    {
        public HallId HallId { get; }
        public ScheduleTime Time { get; }
        public DateTime From { get; }
        public DateTime To { get; }

        public Reservation(HallId hallId, ScheduleTime time, DateTime @from, DateTime to)
        {
            HallId = hallId;
            Time = time;
            From = @from;
            To = to;
        }
    }
}
