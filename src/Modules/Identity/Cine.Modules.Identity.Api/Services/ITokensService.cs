using System;
using Cine.Modules.Identity.Api.DTO;

namespace Cine.Modules.Identity.Api.Services
{
    public interface ITokensService
    {
        void Create(string username);
        bool Validate(string token);
        TokenDto GetToken(string username);
    }
}
