using System;
using Cine.Shared.BuildingBlocks;

namespace Cine.Modules.Schedules.Core.ValueObjects
{
    public sealed class Reservation : ValueObject
    {
        public HallId HallId { get; }
        public DateTime Date { get; }
        public Time Time { get; }

        public Reservation(HallId hallId, DateTime date, Time time)
        {
            HallId = hallId;
            Date = date;
            Time = time;
        }
    }
}
