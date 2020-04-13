using System;
using System.Threading.Tasks;
using Cine.Modules.Identity.Api.DTO;
using Cine.Modules.Identity.Api.Mongo.Documents;
using Convey.CQRS.Queries;
using Convey.Persistence.MongoDB;

namespace Cine.Modules.Identity.Api.Queries.Handlers
{
    public sealed class GetIdentityHandler : IQueryHandler<GetIdentity, IdentityDto>
    {
        private readonly IMongoRepository<IdentityDocument, Guid> _repository;

        public GetIdentityHandler(IMongoRepository<IdentityDocument, Guid> repository)
            => _repository = repository;

        public async Task<IdentityDto> HandleAsync(GetIdentity query)
        {
            var identity = await _repository.GetAsync(i => i.Username == query.Username);
            return identity?.AsDto();
        }
    }
}
