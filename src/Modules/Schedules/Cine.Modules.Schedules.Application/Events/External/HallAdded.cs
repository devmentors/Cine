using System;
using Convey.CQRS.Events;

namespace Cine.Modules.Schedules.Application.Events.External
{
    public sealed class HallAdded : IEvent
    {
        public Guid HallId { get;  }

        public HallAdded(Guid hallId)
        {
            HallId = hallId;
        }
    }
}
