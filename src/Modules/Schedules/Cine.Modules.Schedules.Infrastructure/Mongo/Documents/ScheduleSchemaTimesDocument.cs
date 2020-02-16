using System.Collections.Generic;

namespace Cine.Modules.Schedules.Infrastructure.Mongo.Documents
{
    public class ScheduleSchemaTimesDocument
    {
        public int AgeRestriction { get; set; }
        public IEnumerable<TimeDocument> Times { get; set; }
    }
}
