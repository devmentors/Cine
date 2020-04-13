using Cine.Modules.Identity.Api.DTO;

namespace Cine.Modules.Identity.Api.Services
{
    public interface IAuthTokensService
    {
        AuthDto Create(string username);
        bool Validate(string token);
    }
}
