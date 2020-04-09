using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Cine.Modules.Identity.Api.DTO;
using Cine.Modules.Identity.Api.Options;
using Microsoft.IdentityModel.Tokens;

namespace Cine.Modules.Identity.Api.Services
{
    internal sealed class TokensService : ITokensService
    {
        private readonly IdentityOptions _options;

        public TokensService(IdentityOptions options)
            => _options = options;

        public TokenDto Create(Guid userId)
        {
            var handler = new JwtSecurityTokenHandler();
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, userId.ToString()),
                    new Claim(ClaimTypes.Role, "user"),
                }),
                Expires = DateTime.UtcNow.AddDays(_options.ExpirationDays),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(_options.Key),
                    SecurityAlgorithms.HmacSha256Signature)
            };

            var token = handler.CreateToken(tokenDescriptor);

            return new TokenDto
            {
                Token = handler.WriteToken(token),
                Issuer = token.Issuer,
                ValidFrom = token.ValidFrom,
                ValidTo = token.ValidTo
            };
        }
    }
}
