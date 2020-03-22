using System;
using System.Threading.Tasks;
using Cine.Modules.Schedules.Core;
using Cine.Modules.Schedules.Core.Aggregates;
using Cine.Modules.Schedules.Core.Entities;
using Cine.Modules.Schedules.Core.Repositories;
using Cine.Modules.Schedules.Infrastructure.Mongo.Documents;
using Convey.Persistence.MongoDB;

namespace Cine.Modules.Schedules.Infrastructure.Mongo.Repositories
{
    internal sealed class ScheduleSchemasRepository : IScheduleSchemasRepository
    {
        private readonly IMongoRepository<ScheduleSchemaDocument, Guid> _repository;

        public ScheduleSchemasRepository(IMongoRepository<ScheduleSchemaDocument, Guid> repository)
            => _repository = repository;

        public async Task<ScheduleSchema> GetAsync(CinemaId cinemaId)
        {
            var document = await _repository.GetAsync(ss => ss.CinemaId == cinemaId);

            return document?.AsEntity();
        }

        public Task<bool> ExistsAsync(CinemaId cinemaId)
            => _repository.ExistsAsync(ss => ss.CinemaId == cinemaId);

        public Task AddAsync(ScheduleSchema schema)
            => _repository.AddAsync(schema.AsDocument());

        public Task UpdateAsync(ScheduleSchema schema)
            => _repository.UpdateAsync(schema.AsDocument());
    }
}
