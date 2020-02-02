using System;
using System.Threading.Tasks;
using Cine.Modules.Schedules.Core.Aggregates;
using Cine.Shared.BuildingBlocks;

namespace Cine.Modules.Schedules.Core.Policies
{
    public interface ISchedulePolicy
    {
        Task<Schedule> GenerateScheduleAsync(EntityId Id, CinemaId cinemaId, MovieId movieId, DateTime from, DateTime to, int ageRestriction);
    }
}
