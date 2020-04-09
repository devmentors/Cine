using System;
using Cine.Modules.Identity.Api.DTO;

namespace Cine.Modules.Identity.Api.Services
{
    public interface ITokensService
    {
        void Create(string username);
        TokenDto GetToken(string issuer);
    }
}
