using System.Collections.Generic;
using System.Linq;
using Cine.Modules.Schedules.Core.Events;
using Cine.Modules.Schedules.Core.Exceptions;
using Cine.Modules.Schedules.Core.ValueObjects;
using Cine.Shared.BuildingBlocks;

namespace Cine.Modules.Schedules.Core.Aggregates
{
    public class Schedule : AggregateRoot
    {
        public CinemaId CinemaId { get; private set; }
        public MovieId MovieId { get; private set; }
        public ISet<Show> Shows => _shows;

        private readonly HashSet<Show> _shows;

        public Schedule(EntityId id, CinemaId cinemaId, MovieId movieId, IEnumerable<Show> shows = null, int? version = null)
            : base(id)
        {
            CinemaId = cinemaId;
            MovieId = movieId;
            _shows = shows is null ? new HashSet<Show>() : shows.ToHashSet();
            Version = version ?? 1;
        }

        public static Schedule Create(EntityId id, CinemaId cinemaId, MovieId movieId)
        {
            var schedule = new Schedule(id, cinemaId, movieId);
            schedule.AddDomainEvent(new ScheduleAdded(schedule));
            schedule.Version = 1;
            return schedule;
        }

        public void AddShow(Show show)
        {
            if (show is null)
            {
                throw new EmptyShowException(Id);
            }

            var hasCollidingReservation = _shows
                .Any(r => r.Date.Date == show.Date && r.Time == show.Time);

            if (hasCollidingReservation)
            {
                throw new CollidingScheduleShowException(Id, show.Date, show.Time);
            }

            _shows.Add(show);
            AddDomainEvent(new ShowAdded(this, show));
        }

        public void AddShows(IEnumerable<Show> shows)
        {
            foreach (var reservation in shows)
            {
                AddShow(reservation);
            }
        }
    }
}
