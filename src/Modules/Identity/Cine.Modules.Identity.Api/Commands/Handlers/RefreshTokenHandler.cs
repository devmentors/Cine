using System.Threading.Tasks;
using Cine.Modules.Identity.Api.Services;
using Convey.CQRS.Commands;

namespace Cine.Modules.Identity.Api.Commands.Handlers
{
    public sealed class RefreshTokenHandler : ICommandHandler<UseRefreshToken>, ICommandHandler<RevokeRefreshToken>
    {
        private readonly IRefreshTokensService _service;

        public RefreshTokenHandler(IRefreshTokensService service)
            => _service = service;

        public Task HandleAsync(UseRefreshToken command)
        {
            _service.UseAsync(command.RefreshToken);
            return Task.CompletedTask;
        }

        public Task HandleAsync(RevokeRefreshToken command)
        {
            _service.RevokeAsync(command.RefreshToken);
            return Task.CompletedTask;
        }
    }
}
