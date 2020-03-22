using System;

namespace Cine.Modules.Schedules.Infrastructure.Mongo.Documents
{
    public class ShowDocument
    {
        public Guid HallId { get; set; }
        public DateTime DateTime { get; set; }
    }
}
