using Cine.Shared.Exceptions;

namespace Cine.Modules.Identity.Api.Exceptions
{
    public class UserAlreadyExistsException : AppException
    {
        public override string ErrorCode => "user_already_exists";

        public UserAlreadyExistsException(string username, string email)
            : base($"Username with username: {username} or email {email} already exists.")
        {
        }
    }
}
