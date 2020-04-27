using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cine.Modules.Schedules.Core.Aggregates;
using Cine.Modules.Schedules.Core.Entities;
using Cine.Modules.Schedules.Core.Exceptions;
using Cine.Modules.Schedules.Core.Repositories;
using Cine.Modules.Schedules.Core.ValueObjects;
using Cine.Shared.BuildingBlocks;
using Cine.Shared.Kernel.ValueObjects;

namespace Cine.Modules.Schedules.Core.Policies
{
    public sealed class SchedulePolicy : ISchedulePolicy
    {
        private readonly IScheduleSchemasRepository _scheduleSchemasRepository;
        private readonly ISchedulesRepository _schedulesRepository;
        private readonly IHallsRepository _hallsRepository;
        private const short ShowLength = 4;

        public SchedulePolicy(IScheduleSchemasRepository scheduleSchemasRepository,
            ISchedulesRepository schedulesRepository, IHallsRepository hallsRepository)
        {
            _scheduleSchemasRepository = scheduleSchemasRepository;
            _schedulesRepository = schedulesRepository;
            _hallsRepository = hallsRepository;
        }

        public async Task<Schedule> GenerateScheduleAsync(EntityId id, CinemaId cinemaId, MovieId movieId,
            DateTime from, DateTime to, int ageRestriction)
        {
            var schema = await _scheduleSchemasRepository.GetAsync(cinemaId);

            if (schema is null)
            {
                throw new ScheduleSchemaNotFoundException(cinemaId);
            }

            var times = schema.Times
                .Where(h => h.ageRestriction <= ageRestriction)
                .Select(h => h.times)
                .FirstOrDefault();

            if (times is null)
            {
                throw new MissingScheduleTimesException(cinemaId, ageRestriction);
            }

            var schedules = await _schedulesRepository.GetAsync();
            var schedule = Schedule.Create(id, cinemaId, movieId);

            var shows = schedules.SelectMany(s => s.Shows);

            var dates = Enumerable.Range(0, 1 + to.Subtract(from).Days)
                .Select(offset => from.AddDays(offset))
                .ToList();

            var halls = await _hallsRepository.GetAsync(cinemaId);

            var generatedShows = dates.SelectMany(d =>
                GenerateShowsForDay(d, movieId, shows.ToList(), times.ToList(), halls.ToList()));

            schedule.AddShows(generatedShows);
            return schedule;
        }

        private static IEnumerable<Show> GenerateShowsForDay(DateTime date, MovieId movieId,
            List<Show> shows, List<Time> times, List<Hall> halls)
        {
            var generatedShows = new List<Show>();

            foreach (var time in times)
            {
                foreach (var hall in halls)
                {
                    var collidingShows = shows.Any(r =>
                        r.Date.Date == date.Date && r.HallId == hall.Id && r.Time.CollidesOnPeriod(time, ShowLength));

                    if (collidingShows)
                    {
                        continue;
                    }

                    generatedShows.Add(new Show(hall.Id.Value, date, time));
                    break;
                }
            }

            var hasNotReservedHour = times.Any(t => !generatedShows.Select(r => r.Time).Contains(t));

            if (hasNotReservedHour)
            {
                throw new ImpossibleScheduleShowsException(movieId, date);
            }

            return generatedShows;
        }
    }
}
