using Cine.Shared.Exceptions;

namespace Cine.Modules.Identity.Api.Exceptions
{
    public class InvalidUserPasswordException : AppException
    {
        public override string ErrorCode => "invalid_user_password";

        public InvalidUserPasswordException(string username)
            : base($"Username {username} provided invalid password")
        {
        }
    }
}
