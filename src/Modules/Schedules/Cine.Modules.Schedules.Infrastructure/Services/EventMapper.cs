using System.Collections.Generic;
using System.Linq;
using Cine.Modules.Schedules.Application.Events;
using Cine.Modules.Schedules.Core.Events;
using Cine.Shared.BuildingBlocks;
using Cine.Shared.Events;

namespace Cine.Modules.Schedules.Infrastructure.Services
{
    internal sealed class EventMapper : IEventMapper
    {
        public IEvent Map(IDomainEvent domainEvent)
            => domainEvent switch
            {
                ScheduleAdded e => new ScheduleCreated(e.Schedule.Id),
                ScheduleSchemaAdded e => new ScheduleSchemaCreated(e.Schema.Id),
                ScheduleSchemaTimesChanged e => new ScheduleSchemaUpdated(e.Schema.Id),
                ShowAdded e => new ShowCreated(e.Schedule.Id, e.Show.HallId, e.Show.Date.AddMinutes(e.Show.Time.TotalMinutes)),
                _ => null
            };

        public IEnumerable<IEvent> MapAll(IEnumerable<IDomainEvent> domainEvents)
            => domainEvents.Select(Map);
    }
}
