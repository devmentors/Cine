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
            IdentityDocument identity = null;

            if (query.Username is {})
            {
                identity = await _repository.GetAsync(i => i.Username == query.Username);
            }
            else if (query.UserId.HasValue)
            {
                identity = await _repository.GetAsync(query.UserId.Value);
            }

            return identity?.AsDto();
        }
    }
}
