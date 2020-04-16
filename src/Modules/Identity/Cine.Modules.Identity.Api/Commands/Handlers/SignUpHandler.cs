using System;
using System.Threading.Tasks;
using Cine.Modules.Identity.Api.Exceptions;
using Cine.Modules.Identity.Api.Mongo.Documents;
using Cine.Modules.Identity.Api.Services;
using Cine.Modules.Identity.Api.Validators;
using Cine.Shared.Exceptions;
using Convey.Persistence.MongoDB;

namespace Cine.Modules.Identity.Api.Commands.Handlers
{
    public sealed class SignUpHandler : ICommandHandler<SignUp>
    {
        private readonly ISignUpValidator _validator;
        private readonly IPasswordsService _passwordService;
        private readonly IMongoRepository<IdentityDocument, Guid> _repository;

        public SignUpHandler(ISignUpValidator validator, IPasswordsService passwordService,
            IMongoRepository<IdentityDocument, Guid> repository)
        {
            _validator = validator;
            _passwordService = passwordService;
            _repository = repository;
        }

        public async Task HandleAsync(SignUp command)
        {
            _validator.Validate(command).ThrowIfInvalid();

            var alreadyExists = await _repository.ExistsAsync(u => u.Username == command.Username
                                                                   || u.Email == command.Email);

            if (alreadyExists)
            {
                throw new UserAlreadyExistsException(command.Username, command.Email);
            }

            var salt = _passwordService.CreateSalt();
            var passwordHash = _passwordService.HashPassword(command.Password, salt);

            var user = new IdentityDocument
            {
                Id = command.Id,
                Username = command.Username,
                FullName = command.FullName,
                Email = command.Email,
                PhoneNumber = command.PhoneNumber,
                Password = passwordHash,
                Salt = salt,
                UpdatedAt = DateTime.UtcNow
            };

            await _repository.AddAsync(user);
        }
    }
}
