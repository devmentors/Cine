using System.Collections.Generic;
using System.Linq;
using Cine.Modules.Schedules.Core.Exceptions;
using Cine.Modules.Schedules.Core.ValueObjects;
using Cine.Shared.BuildingBlocks;

namespace Cine.Modules.Schedules.Core.Aggregates
{
    public class Schedule : AggregateRoot
    {
        public CinemaId CinemaId { get; private set; }
        public MovieId MovieId { get; private set; }
        public ISet<Reservation> Reservations => _reservations;

        private readonly HashSet<Reservation> _reservations;

        public Schedule(EntityId id, CinemaId cinemaId, MovieId movieId, IEnumerable<Reservation> reservations = null)
            : base(id)
        {
            CinemaId = cinemaId;
            MovieId = movieId;
            _reservations = reservations is null ? new HashSet<Reservation>() : reservations.ToHashSet();
        }

        public static Schedule Create(EntityId id, CinemaId cinemaId, MovieId movieId)
        {
            var schedule = new Schedule(id, cinemaId, movieId);
            return schedule;
        }

        public void AddReservation(Reservation reservation)
        {
            if (reservation is null)
            {
                throw new EmptyReservationException(Id);
            }

            var hasCollidingReservation = _reservations
                .Any(r => r.Date.Date == reservation.Date && r.Time == reservation.Time);

            if (hasCollidingReservation)
            {
                throw new CollidingScheduleReservationException(Id, reservation.Date, reservation.Time);
            }

            _reservations.Add(reservation);
        }

        public void AddReservations(IEnumerable<Reservation> reservations)
        {
            foreach (var reservation in reservations)
            {
                AddReservation(reservation);
            }
        }
    }
}
