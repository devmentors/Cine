using System.Linq;
using Cine.Modules.Schedules.Core.Exceptions;
using Cine.Shared.BuildingBlocks;

namespace Cine.Modules.Schedules.Core.Entities
{
    public class ScheduleTemplate : IEntity
    {
        public EntityId Id { get; private set; }
        public CinemaId CinemaId { get; private set; }
        public ScheduleTemplateTimes Times { get; private set; }

        public ScheduleTemplate(EntityId id, CinemaId cinemaId, ScheduleTemplateTimes times)
        {
            Id = id;
            CinemaId = cinemaId;
            Times = times;
        }

        public void ChangeTimes(ScheduleTemplateTimes times)
        {
            var duplicatedAges = times
                .GroupBy(t => t.ageRestriction)
                .Where(g => g.Count() > 1)
                .Select(g => g.Key)
                .ToList();

            if (duplicatedAges.Any())
            {
                throw new DuplicatedScheduleTimeException(duplicatedAges);
            }

            Times = times;
        }
    }
}
