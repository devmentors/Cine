using System;
using System.Threading.Tasks;
using Cine.Reservations.Core.Aggregates;
using Cine.Reservations.Core.Repositories;
using Cine.Reservations.Infrastructure.Mongo.Documents;
using Cine.Shared.BuildingBlocks;
using Convey.Persistence.MongoDB;
using MongoDB.Driver;

namespace Cine.Reservations.Infrastructure.Mongo.Repositories
{
    internal sealed class ReservationsRepository : IReservationsRepository
    {
        private readonly IMongoRepository<ReservationDocument, Guid> _repository;

        public ReservationsRepository(IMongoRepository<ReservationDocument, Guid> repository)
            => _repository = repository;

        public async Task<Reservation> GetAsync(EntityId id)
        {
            var document = await _repository.GetAsync(id);
            return document?.AsEntity();
        }

        public Task<bool> ExistsAsync(EntityId id)
            => _repository.ExistsAsync(r => r.Id == id);

        public Task AddAsync(Reservation reservation)
            => _repository.AddAsync(reservation.AsDocument());

        public Task UpdateAsync(Reservation reservation)
            => _repository.Collection.ReplaceOneAsync(r => r.Id == reservation.Id && r.Version < reservation.Version,
                reservation.AsDocument());
    }
}
