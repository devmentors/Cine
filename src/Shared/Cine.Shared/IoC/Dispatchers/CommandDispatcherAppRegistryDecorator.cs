using System;
using System.Linq;
using System.Threading.Tasks;
using Cinema.Shared.IoC.Registries;
using Convey.CQRS.Commands;
using Newtonsoft.Json;

namespace Cinema.Shared.IoC.Dispatchers
{
    internal sealed class CommandDispatcherAppRegistryDecorator : ICommandDispatcher
    {
        private readonly ICommandDispatcher _dispatcher;
        private readonly IAppTypesRegistry _registry;

        public CommandDispatcherAppRegistryDecorator(ICommandDispatcher dispatcher, IAppTypesRegistry registry)
        {
            _dispatcher = dispatcher;
            _registry = registry;
        }

        public async Task SendAsync<T>(T command) where T : class, ICommand
        {
            var commandTypes = _registry.GetLocalTypes(command.GetType());

            if (!commandTypes.Any())
            {
                throw new InvalidOperationException("No command type found in requested module");
            }
            if (commandTypes.Count() > 1)
            {
                throw new InvalidOperationException("Command cannot be processed by more than one module");
            }

            var type = commandTypes.First();
            var json = JsonConvert.SerializeObject(command);
            var message = JsonConvert.DeserializeObject(json, type);

            await (Task)_dispatcher.GetType()
                .GetMethod(nameof(_dispatcher.SendAsync))
                .MakeGenericMethod(type)
                .Invoke(_dispatcher, new object[] { message});
        }
    }
}
