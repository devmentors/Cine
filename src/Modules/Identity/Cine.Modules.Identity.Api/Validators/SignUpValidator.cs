using Cine.Modules.Identity.Api.Commands;
using Valit;

namespace Cine.Modules.Identity.Api.Validators
{
    internal sealed class SignUpValidator : ISignUpValidator
    {
        public IValitResult Validate(SignUp command, IValitStrategy strategy = null)
            => ValitRules<SignUp>
                .Create()
                .WithStrategy(s => s.Complete)
                .Ensure(c => c.Id, _ => _
                    .IsNotEmpty())
                .Ensure(c => c.Username, _ => _
                    .Required())
                .Ensure(c => c.Email, _ => _
                    .Required()
                    .Email())
                .Ensure(c => c.PhoneNumber, _ => _
                    .Required()
                    .MinLength(9))
                .Ensure(c => c.Password, _ => _
                    .Required())
                .For(command)
                .Validate();
    }
}
