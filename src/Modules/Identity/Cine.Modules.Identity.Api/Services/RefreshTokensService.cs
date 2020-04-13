using System;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;
using Cine.Modules.Identity.Api.DTO;
using Cine.Modules.Identity.Api.Exceptions;
using Cine.Modules.Identity.Api.Mongo.Documents;
using Convey.Persistence.MongoDB;

namespace Cine.Modules.Identity.Api.Services
{
    internal sealed class RefreshTokensService : IRefreshTokensService
    {
        private readonly IMongoRepository<RefreshTokenDocument, Guid> _refreshTokensRepository;
        private readonly IMongoRepository<IdentityDocument, Guid> _identitiesRepository;
        private readonly IAuthTokensService _authTokensService;

        public RefreshTokensService(IMongoRepository<RefreshTokenDocument, Guid> refreshTokensRepository,
            IMongoRepository<IdentityDocument, Guid> identitiesRepository, IAuthTokensService authTokensService)
        {
            _refreshTokensRepository = refreshTokensRepository;
            _identitiesRepository = identitiesRepository;
            _authTokensService = authTokensService;
        }

        public async  Task<string> CreateAsync(string username)
        {
            var refreshToken = new RefreshTokenDocument
            {
                Id = Guid.NewGuid(),
                Username = username,
                Token =  Rng.Generate(30, true),
                CreatedAt =  DateTime.UtcNow
            };

            await _refreshTokensRepository.AddAsync(refreshToken);
            return refreshToken.Token;
        }

        public async Task RevokeAsync(string refreshToken)
        {
            var token = await _refreshTokensRepository.GetAsync(rt => rt.Token == refreshToken);
            if (token is null)
            {
                throw new InvalidRefreshTokenException();
            }

            token.RevokedAt = DateTime.UtcNow;
            await _refreshTokensRepository.UpdateAsync(token);
        }

        public async Task<AuthDto> UseAsync(string refreshToken)
        {
            var token = await _refreshTokensRepository.GetAsync(rt => rt.Token == refreshToken);
            if (token is null)
            {
                throw new InvalidRefreshTokenException();
            }

            if (token.IsRevoked)
            {
                throw new RevokedRefreshTokenException();
            }

            var user = await _identitiesRepository.GetAsync(rt => rt.Username == token.Username);
            if (user is null)
            {
                throw new UserNotFoundException(token.Username);
            }

            var auth = _authTokensService.Create(user.Username);
            auth.RefreshToken = refreshToken;
            return auth;
        }

        private static class Rng
        {
            private static readonly string[] SpecialChars = new[] {"/", "\\", "=", "+", "?", ":", "&"};

            public static string Generate(int length = 50, bool removeSpecialChars = true)
            {
                using var rng = new RNGCryptoServiceProvider();
                var bytes = new byte[length];
                rng.GetBytes(bytes);
                var result = Convert.ToBase64String(bytes);

                return removeSpecialChars
                    ? SpecialChars.Aggregate(result, (current, chars) => current.Replace(chars, string.Empty))
                    : result;
            }
        }
    }
}
