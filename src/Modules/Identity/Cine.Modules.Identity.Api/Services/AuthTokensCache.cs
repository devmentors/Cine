using System;
using Cine.Modules.Identity.Api.DTO;
using Microsoft.Extensions.Caching.Memory;

namespace Cine.Modules.Identity.Api.Services
{
    internal sealed class AuthTokensCache : IAuthTokensCache
    {
        private readonly IMemoryCache _cache;

        public AuthTokensCache(IMemoryCache cache)
            => _cache = cache;

        public void Set(AuthDto dto)
            => _cache.Set(dto.Subject, dto, TimeSpan.FromSeconds(30));

        public AuthDto Get(string username)
            => _cache.Get<AuthDto>(username);
    }
}
