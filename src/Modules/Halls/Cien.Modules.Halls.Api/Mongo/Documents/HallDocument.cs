using System;
using System.Collections.Generic;
using Convey.Types;

namespace Cien.Modules.Halls.Api.Mongo.Documents
{
    public class HallDocument : IIdentifiable<Guid>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<SeatDocument> Seats { get; set; }
    }
}
