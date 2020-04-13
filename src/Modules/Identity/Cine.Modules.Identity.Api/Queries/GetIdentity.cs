using System;
using Cine.Modules.Identity.Api.DTO;
using Convey.CQRS.Queries;

namespace Cine.Modules.Identity.Api.Queries
{
    public class GetIdentity : IQuery<IdentityDto>
    {
        public string Username { get; set; }
        public Guid? UserId { get; set; }
    }
}
