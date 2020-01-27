using System;
using Cine.Shared.BuildingBlocks;

namespace Cine.Modules.Schedules.Core.Entities
{
    public class Schedule : AggregateRoot
    {
        public MovieId MovieId { get; private set; }
        public int ShowsPerDay { get; set; }
        

        public Schedule(Guid id) : base(id)
        {
        }
    }
}
