using System.Threading.Tasks;
using Cine.Modules.Identity.Api.Commands;
using Cine.Modules.Identity.Api.DTO;
using Cine.Modules.Identity.Api.Services;
using Convey.CQRS.Commands;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Cine.Modules.Identity.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class IdentityController : ControllerBase
    {
        private readonly ICommandDispatcher _commandDispatcher;
        private readonly IAuthTokensCache _authTokensCache;
        private readonly IRefreshTokensService _refreshTokensService;

        public IdentityController(ICommandDispatcher commandDispatcher, IAuthTokensCache authTokensCache,
            IRefreshTokensService refreshTokensService)
        {
            _commandDispatcher = commandDispatcher;
            _refreshTokensService = refreshTokensService;
            _authTokensCache = authTokensCache;
        }

        [HttpGet("me")]
        public async Task<ActionResult<UserDto>> GetMe()
        {
            var a = User;
            return Ok();
        }

        [HttpPost("sign-up")]
        [AllowAnonymous]
        public async Task<IActionResult> SignUp([FromBody] SignUp command)
        {
            await _commandDispatcher.SendAsync(command);
            return Ok();
        }

        [HttpPost("sign-in")]
        [AllowAnonymous]
        public async Task<ActionResult<AuthDto>> SignIn([FromBody] SignIn command)
        {
            await _commandDispatcher.SendAsync(command);
            var token = _authTokensCache.Get(command.Username);

            return Ok(token);
        }

        [HttpPost("refresh-token/use")]
        public async Task<ActionResult<AuthDto>> UseRefreshToken([FromBody] UseRefreshToken command)
            => Ok(await _refreshTokensService.UseAsync(command.RefreshToken));


        [HttpPost("refresh-token/revoke")]
        public async Task<IActionResult> RevokeRefreshToken([FromBody] RevokeRefreshToken command)
        {
            await _refreshTokensService.RevokeAsync(command.RefreshToken);
            return Ok();
        }

        [HttpPost("password/change")]
        public async Task<IActionResult> ChangePassword([FromBody] ChangePassword command)
        {
            await _commandDispatcher.SendAsync(command);
            return Ok();
        }
    }
}
