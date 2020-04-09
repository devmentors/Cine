using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Cine.Modules.Identity.Api.DTO;
using Cine.Modules.Identity.Api.Options;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.IdentityModel.Tokens;

namespace Cine.Modules.Identity.Api.Services
{
    internal sealed class TokensService : ITokensService
    {
        private readonly IdentityOptions _options;
        private readonly IMemoryCache _cache;

        public TokensService(IdentityOptions options, IMemoryCache cache)
        {
            _options = options;
            _cache = cache;
        }

        public void Create(string username)
        {
            var handler = new JwtSecurityTokenHandler();
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.Name, username),
                    new Claim(ClaimTypes.Role, "user"),
                }),
                Expires = DateTime.UtcNow.AddDays(_options.ExpirationDays),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(_options.Key),
                    SecurityAlgorithms.HmacSha256Signature)
            };

            var securityToken = handler.CreateToken(tokenDescriptor);
            var token = new TokenDto
            {
                Token = handler.WriteToken(securityToken),
                Issuer = securityToken.Issuer,
                ValidFrom = securityToken.ValidFrom,
                ValidTo = securityToken.ValidTo
            };

            _cache.Set(token.Issuer, token);
        }

        public TokenDto GetToken(string issuer)
            => _cache.Get<TokenDto>(issuer);
    }
}
