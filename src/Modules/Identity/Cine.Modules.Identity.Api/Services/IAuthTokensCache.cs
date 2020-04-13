using Cine.Modules.Identity.Api.DTO;

namespace Cine.Modules.Identity.Api.Services
{
    public interface IAuthTokensCache
    {
        void Set(AuthDto dto);
        AuthDto Get(string username);
    }
}
