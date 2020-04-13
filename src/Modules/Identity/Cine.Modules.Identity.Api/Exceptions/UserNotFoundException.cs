using System;
using Cine.Shared.Exceptions;

namespace Cine.Modules.Identity.Api.Exceptions
{
    public class UserNotFoundException : AppException
    {
        public override string ErrorCode => "user_not_found";

        public UserNotFoundException(string username) : base($"User with username {username} was not found")
        {
        }

        public UserNotFoundException(Guid userId) : base($"User with id {userId} was not found")
        {
        }
    }
}
