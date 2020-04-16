using System;
using Cine.Shared.Mongo;

namespace Cine.Modules.Schedules.Infrastructure.Mongo.Documents
{
    public class HallDocument : IIdentifiable<Guid>
    {
        public Guid Id { get; set; }
        public Guid CinemaId { get; set; }
    }
}
