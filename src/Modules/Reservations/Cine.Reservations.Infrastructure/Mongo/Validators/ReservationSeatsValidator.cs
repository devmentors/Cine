using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cine.Reservations.Core;
using Cine.Reservations.Core.Validators;
using Cine.Reservations.Core.ValueObjects;
using Cine.Reservations.Infrastructure.Mongo.Documents;
using Convey.Persistence.MongoDB;

namespace Cine.Reservations.Infrastructure.Mongo.Validators
{
    internal sealed class ReservationSeatsValidator : IReservationSeatsValidator
    {
        private readonly IMongoRepository<ReservationDocument, Guid> _repository;

        public ReservationSeatsValidator(IMongoRepository<ReservationDocument, Guid> repository)
            => _repository = repository;

        public async Task<bool> ValidateAsync(CinemaId cinemaId, MovieId movieId, HallId hallId, IEnumerable<Seat> seats)
        {
            var movieReservations = await _repository
                .FindAsync(r => r.CinemaId == cinemaId && r.MovieId == movieId && r.HallId == hallId);

            var isValid = !movieReservations.Any(r =>
                r.Seats.Any(s => seats.Any(ss => ss.Row == s.Row && ss.Number == s.Number)));

            return isValid;
        }
    }
}
