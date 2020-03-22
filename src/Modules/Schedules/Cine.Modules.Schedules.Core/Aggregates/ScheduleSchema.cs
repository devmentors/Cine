using System.Linq;
using Cine.Modules.Schedules.Core.Exceptions;
using Cine.Modules.Schedules.Core.Types;
using Cine.Shared.BuildingBlocks;

namespace Cine.Modules.Schedules.Core.Aggregates
{
    public class ScheduleSchema : AggregateRoot
    {
        public CinemaId CinemaId { get; private set; }
        public ScheduleSchemaTimes Times { get; private set; }

        public ScheduleSchema(EntityId id, CinemaId cinemaId, ScheduleSchemaTimes times) : base(id)
        {
            Id = id;
            CinemaId = cinemaId;
            Times = times;
        }

        public void ChangeTimes(ScheduleSchemaTimes times)
        {
            var duplicatedTimes = times
                .GroupBy(h => h.ageRestriction)
                .Where(g => g.Count() > 1)
                .Select(g => g.Key)
                .ToList();

            if (duplicatedTimes.Any())
            {
                throw new DuplicatedScheduleTimeException(duplicatedTimes);
            }

            Times = times;
        }
    }
}
