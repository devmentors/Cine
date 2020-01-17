using System;
using System.Collections.Generic;
using Convey.Types;

namespace Cine.Modules.Cinemas.Api.Mongo.Documents
{
    public class CinemaDocument : IIdentifiable<Guid>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public AddressDocument Address { get; set; }
        public IEnumerable<HallDocument> Halls { get; set; }
    }
}
