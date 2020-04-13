using System;
using System.Threading.Tasks;
using Cine.Modules.Identity.Api.DTO;

namespace Cine.Modules.Identity.Api.Services
{
    public interface IAuthTokensService
    {
        Task<AuthDto> CreateAsync(string username);
        bool Validate(string token);
        AuthDto GetToken(string username);
    }
}
