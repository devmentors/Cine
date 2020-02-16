using System;
using Convey.CQRS.Commands;

namespace Cine.Modules.Schedules.Application.Commands
{
    public class GenerateSchedule : ICommand
    {
        public Guid Id { get; }
        public Guid CinemaId { get; }
        public Guid MovieId { get;  }
        public DateTime From { get; }
        public DateTime To { get; }

        public GenerateSchedule(Guid id, Guid cinemaId, Guid movieId, DateTime from, DateTime to)
        {
            Id = id;
            CinemaId = cinemaId;
            MovieId = movieId;
            From = from;
            To = to;
        }
    }
}
