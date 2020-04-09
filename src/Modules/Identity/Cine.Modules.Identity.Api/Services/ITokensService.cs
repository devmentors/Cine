using System;
using Cine.Modules.Identity.Api.DTO;

namespace Cine.Modules.Identity.Api.Services
{
    public interface ITokensService
    {
        TokenDto Create(Guid userId);
    }
}
