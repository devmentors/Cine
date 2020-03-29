using Cine.Shared.Exceptions;

namespace Cine.Shared.Kernel.Exceptions
{
    public class InvalidEmailException : DomainException
    {
        public override string ErrorCode => "invalid_email";

        public InvalidEmailException(string email) : base($"Invalid email: {email}")
        {
        }
    }
}
