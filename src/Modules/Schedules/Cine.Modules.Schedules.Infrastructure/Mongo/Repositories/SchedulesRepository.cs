using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cine.Modules.Schedules.Core;
using Cine.Modules.Schedules.Core.Aggregates;
using Cine.Modules.Schedules.Core.Repositories;
using Cine.Modules.Schedules.Infrastructure.Mongo.Documents;
using Cine.Shared.BuildingBlocks;
using Convey.Persistence.MongoDB;
using MongoDB.Driver;

namespace Cine.Modules.Schedules.Infrastructure.Mongo.Repositories
{
    internal sealed class SchedulesRepository : ISchedulesRepository
    {
        private readonly IMongoRepository<ScheduleDocument, Guid> _repository;

        public SchedulesRepository(IMongoRepository<ScheduleDocument, Guid> repository)
            => _repository = repository;

        public async Task<IEnumerable<Schedule>> GetAsync()
        {
            var documents =  await _repository.FindAsync(_ => true);
            return documents?.Select(s => s.AsEntity());
        }

        public async Task<Schedule> GetAsync(EntityId id)
        {
            var document = await _repository.GetAsync(id);
            return document?.AsEntity();
        }

        public Task<bool> ExistsAsync(CinemaId cinemaId, MovieId movieId)
            => _repository.ExistsAsync(s => s.CinemaId == cinemaId && s.MovieId == movieId);

        public Task AddAsync(Schedule schedule)
            => _repository.AddAsync(schedule.AsDocument());

        public Task UpdateAsync(Schedule schedule)
            => _repository.Collection.ReplaceOneAsync(s => s.Id == schedule.Id && s.Version < schedule.Version,
                schedule.AsDocument());

        public Task DeleteAsync(EntityId id)
            => _repository.DeleteAsync(id);
    }
}
