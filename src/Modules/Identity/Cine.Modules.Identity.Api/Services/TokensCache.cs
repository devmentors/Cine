using Cine.Modules.Identity.Api.DTO;
using Microsoft.Extensions.Caching.Memory;

namespace Cine.Modules.Identity.Api.Services
{
    internal sealed class TokensCache : ITokensCache
    {
        private readonly IMemoryCache _cache;

        public TokensCache(IMemoryCache cache)
            => _cache = cache;

        public void Insert(TokenDto token)
            => _cache.Set(token.Issuer, token);

        public TokenDto Get(string issuer)
            => _cache.Get<TokenDto>(issuer);
    }
}
