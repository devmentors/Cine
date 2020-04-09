using System.Threading.Tasks;
using Cine.Modules.Identity.Api.DTO;

namespace Cine.Modules.Identity.Api.Services
{
    public interface ITokensCache
    {
        void Insert(TokenDto token);
        TokenDto Get(string issuer);
    }
}
