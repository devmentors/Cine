using System;
using System.Linq;
using System.Threading.Tasks;
using Cine.Modules.Cinemas.Api.DTO;
using Cine.Modules.Cinemas.Api.Events;
using Cine.Modules.Cinemas.Api.Mongo;
using Cine.Modules.Cinemas.Api.Mongo.Documents;
using Convey.Persistence.MongoDB;
using MongoDB.Driver;
using MongoDB.Driver.Linq;

namespace Cine.Modules.Cinemas.Api.Services
{
    public sealed class CinemasService : ICinemasService
    {
        private readonly IMongoRepository<CinemaDocument, Guid> _repository;
        private readonly IMessageBroker _broker;

        public CinemasService(IMongoRepository<CinemaDocument, Guid> repository, IMessageBroker broker)
        {
            _repository = repository;
            _broker = broker;
        }

        public async Task<CinemaDto> GetAsync(Guid id)
        {
            var document = await _repository.GetAsync(id);
            return document?.AsDto();
        }

        public async Task<HallDto> GetHallAsync(Guid hallId)
        {
            var document = await _repository.Collection
                .AsQueryable()
                .Where(c => c.Halls.Any(h => h.Id == hallId))
                .Select(c => c.Halls.FirstOrDefault(h => h.Id == hallId))
                .FirstOrDefaultAsync();

            return document?.AsDto();
        }

        public async Task CreateAsync(CinemaDto dto)
        {
            await _repository.AddAsync(dto.AsDocument());

            var events = dto.Halls.Select(h => new HallAdded(h.Id));
            await _broker.PublishAsync(events);
        }

        public Task UpdateAsync(CinemaDto dto)
            => _repository.UpdateAsync(dto.AsDocument());

        public Task DeleteAsync(Guid id)
            => _repository.DeleteAsync(id);
    }
}
