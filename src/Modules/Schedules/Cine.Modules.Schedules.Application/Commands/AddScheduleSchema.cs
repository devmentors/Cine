using System;
using Cine.Modules.Schedules.Core.Entities;
using Convey.CQRS.Commands;

namespace Cine.Modules.Schedules.Application.Commands
{
    public class AddScheduleSchema : ICommand
    {
        public Guid Id { get;  }
        public Guid CinemaId { get; }
        public ScheduleSchemaTimes Times { get; }

        public AddScheduleSchema(Guid id, Guid cinemaId, ScheduleSchemaTimes times)
        {
            Id = id;
            CinemaId = cinemaId;
            Times = times;
        }
    }
}
