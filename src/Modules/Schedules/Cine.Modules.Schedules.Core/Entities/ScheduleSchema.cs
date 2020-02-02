using System.Linq;
using Cine.Modules.Schedules.Core.Exceptions;
using Cine.Shared.BuildingBlocks;

namespace Cine.Modules.Schedules.Core.Entities
{
    public class ScheduleSchema : IEntity
    {
        public EntityId Id { get; private set; }
        public CinemaId CinemaId { get; private set; }
        public ScheduleSchemaHours Hours { get; private set; }

        public ScheduleSchema(EntityId id, CinemaId cinemaId, ScheduleSchemaHours hours)
        {
            Id = id;
            CinemaId = cinemaId;
            Hours = hours;
        }

        public void ChangeHours(ScheduleSchemaHours hours)
        {
            var duplicatedAges = hours
                .GroupBy(h => h.ageRestriction)
                .Where(g => g.Count() > 1)
                .Select(g => g.Key)
                .ToList();

            if (duplicatedAges.Any())
            {
                throw new DuplicatedScheduleTimeException(duplicatedAges);
            }

            Hours = hours;
        }
    }
}
