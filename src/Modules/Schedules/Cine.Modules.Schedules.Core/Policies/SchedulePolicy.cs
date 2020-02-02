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

namespace Cine.Modules.Schedules.Core.Policies
{
    internal sealed class SchedulePolicy : ISchedulePolicy
    {
        private readonly IScheduleSchemasRepository _scheduleSchemasRepository;
        private readonly ISchedulesRepository _schedulesRepository;
        private readonly IHallsRepository _hallsRepository;
        private const short ReservationLength = 4;

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
            var scheme = await _scheduleSchemasRepository.GetAsync(cinemaId);

            if (scheme is null)
            {
                throw new ScheduleSchemaNotFoundException(cinemaId);
            }

            var times = scheme.Hours
                .Where(h => h.ageRestriction <= ageRestriction)
                .Select(h => h.scheduleTimes)
                .FirstOrDefault();

            if (times is null)
            {
                throw new MissingScheduleTimesException(cinemaId, ageRestriction);
            }

            var schedules = await _schedulesRepository.GetAsync();
            var schedule = Schedule.Create(id, cinemaId, movieId);

            var reservations = schedules.SelectMany(s => s.Reservations);

            var dates = Enumerable.Range(0, 1 + to.Subtract(from).Days)
                .Select(offset => from.AddDays(offset))
                .ToList();

            var halls = await _hallsRepository.GetAsync();

            var generatedReservations = dates.SelectMany(d =>
                GenerateReservationsForDay(d, movieId, reservations.ToList(), times.ToList(), halls.ToList()));

            schedule.AddReservations(generatedReservations);
            return schedule;
        }

        private static IEnumerable<Reservation> GenerateReservationsForDay(DateTime date, MovieId movieId,
            List<Reservation> reservations, List<ScheduleTime> times, List<Hall> halls)
        {
            var generatedReservations = new List<Reservation>();

            foreach (var time in times)
            {
                foreach (var hall in halls)
                {
                    var hasAlreadyReserved = reservations
                        .Any(r => r.Date.Date == date.Date && r.HallId == hall.Id);

                    var hasCollidingReservations = reservations
                        .Any(r => r.Time.CollidesOnPeriod(time, ReservationLength));

                    if (hasAlreadyReserved || hasCollidingReservations)
                    {
                        continue;
                    }

                    generatedReservations.Add(new Reservation(hall.Id.Value, date, time));
                    break;
                }
            }

            var hasNotReservedHour = times.Any(t => !generatedReservations.Select(r => r.Time).Contains(t));

            if (hasNotReservedHour)
            {
                throw new ImpossibleScheduleReservationException(movieId, date);
            }

            return generatedReservations;
        }
    }
}
