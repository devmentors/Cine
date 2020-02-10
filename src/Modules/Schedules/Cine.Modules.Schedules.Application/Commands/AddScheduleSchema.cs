using System;
using System.Collections.Generic;
using Cine.Modules.Schedules.Core.ValueObjects;
using Convey.CQRS.Commands;

namespace Cine.Modules.Schedules.Application.Commands
{
    public class AddScheduleSchema : ICommand
    {
        public Guid Id { get;  }
        public Guid CinemaId { get; }
        public IEnumerable<(int ageRestriction, IEnumerable<ScheduleTime> scheduleTimes)> Times { get; }

        public AddScheduleSchema(Guid id, Guid cinemaId, IEnumerable<(int ageRestriction,
            IEnumerable<ScheduleTime> scheduleTimes)> times)
        {
            Id = id;
            CinemaId = cinemaId;
            Times = times;
        }
    }
}
