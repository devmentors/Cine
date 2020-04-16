using System;
using System.Collections.Generic;
using Convey.Types;

namespace Cine.Modules.Schedules.Infrastructure.Mongo.Documents
{
    public class ScheduleSchemaDocument : IIdentifiable<Guid>
    {
        public Guid Id { get; set; }
        public Guid CinemaId { get; set; }
        public IEnumerable<ScheduleSchemaTimesDocument> Times { get; set; }
        public int Version { get; set; }
    }
}
