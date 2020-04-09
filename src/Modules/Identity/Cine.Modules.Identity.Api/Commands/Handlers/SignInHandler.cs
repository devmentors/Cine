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
        private readonly ITokensService _tokensService;
        private readonly IMongoRepository<UserDocument, Guid> _repository;

        public SignInHandler(IPasswordsService passwordService, ITokensService tokensService,
            IMongoRepository<UserDocument, Guid> repository)
        {
            _passwordService = passwordService;
            _tokensService = tokensService;
            _repository = repository;
        }

        public async Task HandleAsync(SignIn command)
        {
            var user = await _repository.GetAsync(u => u.Username == command.Username);

            if (user is null)
            {
                throw new UserNotFoundException(command.Username);
            }

            var passwordHash = _passwordService.HashPassword(command.Password);

            if (passwordHash != user.Password)
            {
                throw new InvalidUserPasswordException(user.Username);
            }

            _tokensService.Create(user.Username);
        }
    }
}
