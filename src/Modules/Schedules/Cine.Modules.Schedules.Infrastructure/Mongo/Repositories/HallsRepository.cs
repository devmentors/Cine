using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cine.Modules.Schedules.Core;
using Cine.Modules.Schedules.Core.Entities;
using Cine.Modules.Schedules.Core.Repositories;
using Cine.Modules.Schedules.Infrastructure.Mongo.Documents;
using Cine.Shared.BuildingBlocks;
using Convey.Persistence.MongoDB;

namespace Cine.Modules.Schedules.Infrastructure.Mongo.Repositories
{
    internal sealed class HallsRepository : IHallsRepository
    {
        private readonly IMongoRepository<HallDocument, Guid> _repository;

        public HallsRepository(IMongoRepository<HallDocument, Guid> repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Hall>> GetAsync(CinemaId cinemaId)
        {
            var documents = await _repository.FindAsync(h => h.CinemaId == cinemaId);
            return documents?.Select(d => d.AsEntity());
        }

        public Task<bool> ExistsAsync(HallId hallId)
            => _repository.ExistsAsync(h => h.Id == hallId);

        public Task AddAsync(Hall hall)
            => _repository.AddAsync(hall.AsDocument());

        public Task DeleteAsync(EntityId id)
            => _repository.DeleteAsync(id);
    }
}
