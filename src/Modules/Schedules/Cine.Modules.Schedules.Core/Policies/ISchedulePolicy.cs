using System;
using Cine.Modules.Schedules.Core.Aggregates;

namespace Cine.Modules.Schedules.Core.Policies
{
    public interface ISchedulePolicy
    {
        Schedule GenerateSchedule(DateTime from, DateTime to, CinemaId cinemaId, MovieId movieId, int ageRestriction);
    }
}
