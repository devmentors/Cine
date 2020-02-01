using System;
using System.Collections.Generic;
using Cine.Modules.Schedules.Core.ValueObjects;
using Cine.Shared.BuildingBlocks;

namespace Cine.Modules.Schedules.Core.Aggregates
{
    public class Schedule : AggregateRoot
    {
        public CinemaId CinemaId { get; private set; }
        public MovieId MovieId { get; private set; }
        public IEnumerable<Reservation> Reservations { get; private set; }

        public Schedule(EntityId id, CinemaId cinemaId, MovieId movieId, IEnumerable<Reservation> reservations)
            : base(id)
        {
            CinemaId = cinemaId;
            MovieId = movieId;
            Reservations = reservations;
        }

        public void AddReservation(Reservation reservation)
        {
            if (reservation is null)
            {

            }
        }
    }
}
