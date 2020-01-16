using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cine.Modules.Movies.Api.DTO;
using Cine.Modules.Movies.Api.Mongo;
using Cine.Modules.Movies.Api.Mongo.Documents;
using Convey.Persistence.MongoDB;
using MongoDB.Driver;
using MongoDB.Driver.Linq;

namespace Cine.Modules.Movies.Api.Services
{
    public sealed class MoviesService : IMoviesService
    {
        private readonly IMongoRepository<MovieDocument, Guid> _repository;

        public MoviesService(IMongoRepository<MovieDocument, Guid> repository)
            =>  _repository = repository;

        public async Task<MovieDto> GetAsync(Guid id)
        {
            var document = await _repository.GetAsync(id);
            return document?.AsDto();
        }

        public async Task<IEnumerable<MovieDto>> SearchAsync(string searchPhrase)
        {
            var query = _repository.Collection.AsQueryable();

            var isEnum = Enum.TryParse<Genre>(searchPhrase, out var @enum);

            query = isEnum
                ? query.Where(m => m.Title.Contains(searchPhrase) || m.Genres.HasFlag(@enum))
                : query.Where(m => m.Title.Contains(searchPhrase));

            var documents = await query.ToListAsync();
            return documents.Select(d => d.AsDto());
        }

        public Task CreateAsync(MovieDto dto)
            => _repository.AddAsync(dto.AsDocument());

        public Task UpdateAsync(MovieDto dto)
            => _repository.UpdateAsync(dto.AsDocument());

        public Task DeleteAsync(Guid id)
            => _repository.DeleteAsync(id);
    }
}
