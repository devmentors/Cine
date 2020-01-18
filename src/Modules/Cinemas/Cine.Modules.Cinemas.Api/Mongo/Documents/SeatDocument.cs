using System;
using Convey.Types;

namespace Cine.Modules.Cinemas.Api.Mongo.Documents
{
    public class SeatDocument : IIdentifiable<Guid>
    {
        public Guid Id { get; set; }
        public string Row { get; set; }
        public int Number { get; set; }
        public bool IsVip { get; set; }
        public int RenderPositionX { get; set; }
        public int RenderPositionY { get; set; }
    }
}
