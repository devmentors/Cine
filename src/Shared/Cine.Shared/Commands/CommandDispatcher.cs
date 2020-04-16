using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;

namespace Cine.Shared.Commands
{
    internal sealed class CommandDispatcher : ICommandDispatcher
    {
        private readonly IServiceScopeFactory _serviceFactory;

        public CommandDispatcher(IServiceScopeFactory serviceFactory)
            => _serviceFactory = serviceFactory;

        public async Task SendAsync<TCommand>(TCommand command) where TCommand : class, ICommand
        {
            using var scope = _serviceFactory.CreateScope();
            var handler = scope.ServiceProvider.GetRequiredService<ICommandHandler<TCommand>>();
            await handler.HandleAsync(command);
        }
    }
}
