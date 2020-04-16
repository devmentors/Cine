using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Cine.Modules.Identity.Api.DTO;
using Cine.Modules.Identity.Api.Options;
using Microsoft.IdentityModel.Tokens;

namespace Cine.Modules.Identity.Api.Services
{
    internal sealed class AuthTokensService : IAuthTokensService
    {
        private readonly IdentityOptions _options;

        public AuthTokensService(IdentityOptions options)
            => _options = options;

        public AuthDto Create(string username)
        {
            var handler = new JwtSecurityTokenHandler();
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Issuer = _options.Issuer,
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

            var token = new AuthDto
            {
                Token = handler.WriteToken(securityToken),
                Issuer = securityToken.Issuer,
                Subject = username,
                ValidFrom = securityToken.ValidFrom,
                ValidTo = securityToken.ValidTo
            };

            return token;
        }

        public bool Validate(string token)
        {
            var handler = new JwtSecurityTokenHandler();
            var signingKey = new SymmetricSecurityKey(_options.Key);
            try
            {
                var jwt = handler.ReadToken(token);

                handler.ValidateToken(token, new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    ValidateIssuer = true,
                    ValidateAudience = false,
                    ValidIssuer = jwt.Issuer,
                    IssuerSigningKey = signingKey
                }, out _);
            }
            catch
            {
                return false;
            }
            return true;
        }
    }
}
