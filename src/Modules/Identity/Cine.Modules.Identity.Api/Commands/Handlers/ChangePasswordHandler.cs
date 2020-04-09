using System;
using System.Threading.Tasks;
using Cine.Modules.Identity.Api.Exceptions;
using Cine.Modules.Identity.Api.Mongo.Documents;
using Cine.Modules.Identity.Api.Services;
using Convey.CQRS.Commands;
using Convey.Persistence.MongoDB;

namespace Cine.Modules.Identity.Api.Commands.Handlers
{
    public class ChangePasswordHandler : ICommandHandler<ChangePassword>
    {
        private readonly IMongoRepository<UserDocument, Guid> _repository;
        private readonly IPasswordsService _passwordsService;

        public ChangePasswordHandler(IMongoRepository<UserDocument, Guid> repository, IPasswordsService passwordsService)
        {
            _repository = repository;
            _passwordsService = passwordsService;
        }

        public async Task HandleAsync(ChangePassword command)
        {
            var user = await _repository.GetAsync(u => u.Username == command.Username);

            if (user is null)
            {
                throw new UserNotFoundException(command.Username);
            }

            var salt = _passwordsService.CreateSalt();
            var hashedPassword = _passwordsService.HashPassword(command.NewPassword, salt);

            user.Salt = salt;
            user.Password = hashedPassword;

            await _repository.UpdateAsync(user);
        }
    }
}
