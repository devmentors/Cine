using System;
using System.Collections.Generic;
using Cine.Modules.Schedules.Application.Commands.WriteModels;
using Convey.CQRS.Commands;

namespace Cine.Modules.Schedules.Application.Commands
{
    public class CreateScheduleSchema : ICommand
    {
        public Guid Id { get;  }
        public Guid CinemaId { get; }
        public IEnumerable<ScheduleSchemaTimesWriteModel> Times { get; }

        public CreateScheduleSchema(Guid id, Guid cinemaId, IEnumerable<ScheduleSchemaTimesWriteModel> times)
        {
            Id = id;
            CinemaId = cinemaId;
            Times = times;
        }
    }
}
