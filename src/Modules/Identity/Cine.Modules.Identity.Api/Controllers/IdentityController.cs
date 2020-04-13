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
        private readonly ICommandDispatcher _dispatcher;
        private readonly IAuthTokensService _service;

        public IdentityController(ICommandDispatcher dispatcher, IAuthTokensService service)
        {
            _dispatcher = dispatcher;
            _service = service;
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
            await _dispatcher.SendAsync(command);
            return Ok();
        }

        [HttpPost("sign-in")]
        [AllowAnonymous]
        public async Task<ActionResult<AuthDto>> SignIn([FromBody] SignIn command)
        {
            await _dispatcher.SendAsync(command);
            var token = _service.GetToken(command.Username);

            return Ok(token);
        }

        [HttpPost("password/change")]
        public async Task<IActionResult> ChangePassword([FromBody] ChangePassword command)
        {
            await _dispatcher.SendAsync(command);
            return Ok();
        }
    }
}
