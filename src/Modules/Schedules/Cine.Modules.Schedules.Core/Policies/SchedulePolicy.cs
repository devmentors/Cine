using System;
using Cine.Modules.Schedules.Core.Aggregates;

namespace Cine.Modules.Schedules.Core.Policies
{
    public class SchedulePolicy : ISchedulePolicy
    {
        public Schedule GenerateSchedule(DateTime @from, DateTime to, CinemaId cinemaId, MovieId movieId, int ageRestriction)
        {
            throw new NotImplementedException();
        }
    }
}
