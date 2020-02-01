using System;
using Cine.Shared.BuildingBlocks;

namespace Cine.Modules.Schedules.Core.ValueObjects
{
    public sealed class Reservation : ValueObject
    {
        public HallId HallId { get; }
        public DateTime Date { get; }
        public ScheduleTime Time { get; }

        public Reservation(HallId hallId, DateTime date, ScheduleTime time)
        {
            HallId = hallId;
            Date = date;
            Time = time;
        }
    }
}
