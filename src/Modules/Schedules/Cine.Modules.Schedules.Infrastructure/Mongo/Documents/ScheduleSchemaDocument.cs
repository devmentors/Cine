using System;
using System.Collections.Generic;
using Cine.Modules.Schedules.Core.ValueObjects;
using Convey.Types;

namespace Cine.Modules.Schedules.Infrastructure.Mongo.Documents
{
    public class ScheduleSchemaDocument : IIdentifiable<Guid>
    {
        public Guid Id { get; set; }
        public Guid CinemaId { get; set; }
        public IEnumerable<(int ageRestriction, IEnumerable<ScheduleTime> scheduleTimes)> Hours { get; set; }
    }
}
