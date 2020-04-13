using Cine.Shared.Exceptions;

namespace Cine.Modules.Identity.Api.Exceptions
{
    public class InvalidRefreshTokenException : AppException
    {
        public override string ErrorCode => "invalid_refresh_token";

        public InvalidRefreshTokenException() : base("Provided refresh token was invalid")
        {
        }
    }
}
