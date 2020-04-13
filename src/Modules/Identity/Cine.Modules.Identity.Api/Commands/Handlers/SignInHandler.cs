using System;
using System.Threading.Tasks;
using Cine.Modules.Identity.Api.Exceptions;
using Cine.Modules.Identity.Api.Mongo.Documents;
using Cine.Modules.Identity.Api.Services;
using Convey.CQRS.Commands;
using Convey.Persistence.MongoDB;

namespace Cine.Modules.Identity.Api.Commands.Handlers
{
    public sealed class SignInHandler : ICommandHandler<SignIn>
    {
        private readonly IPasswordsService _passwordService;
        private readonly IAuthTokensService _authTokensService;
        private readonly IRefreshTokensService _refreshTokensService;
        private readonly IAuthTokensCache _cache;
        private readonly IMongoRepository<IdentityDocument, Guid> _repository;

        public SignInHandler(IPasswordsService passwordService, IAuthTokensService authTokensService,
            IRefreshTokensService refreshTokensService, IAuthTokensCache cache, IMongoRepository<IdentityDocument, Guid> repository)
        {
            _passwordService = passwordService;
            _authTokensService = authTokensService;
            _repository = repository;
            _cache = cache;
            _refreshTokensService = refreshTokensService;
        }

        public async Task HandleAsync(SignIn command)
        {
            var user = await _repository.GetAsync(u => u.Username == command.Username);

            if (user is null)
            {
                throw new UserNotFoundException(command.Username);
            }

            var passwordHash = _passwordService.HashPassword(command.Password, user.Salt);

            if (passwordHash != user.Password)
            {
                throw new InvalidUserPasswordException(user.Username);
            }

            var token = _authTokensService.Create(user.Username);
            var refreshToken = await _refreshTokensService.CreateAsync(user.Username);

            token.RefreshToken = refreshToken;
            _cache.Set(token);
        }
    }
}
