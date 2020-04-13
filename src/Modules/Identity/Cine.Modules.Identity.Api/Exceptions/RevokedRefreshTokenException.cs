using Cine.Shared.Exceptions;

namespace Cine.Modules.Identity.Api.Exceptions
{
    public class RevokedRefreshTokenException : AppException
    {
        public override string ErrorCode => "revoked_refresh_token";

        public RevokedRefreshTokenException() : base("Provided refresh token has been revoked")
        {
        }
    }
}
