using System.Threading.Tasks;
using Cinema.Shared.IoC.Registries;
using Convey.CQRS.Events;
using Newtonsoft.Json;

namespace Cinema.Shared.IoC.Dispatchers
{
    internal sealed class EventDispatcherAppRegistryDecorator : IEventDispatcher
    {
        private readonly IEventDispatcher _dispatcher;
        private readonly IAppTypesRegistry _registry;

        public EventDispatcherAppRegistryDecorator(IEventDispatcher dispatcher, IAppTypesRegistry registry)
        {
            _dispatcher = dispatcher;
            _registry = registry;
        }

        public async Task PublishAsync<T>(T @event) where T : class, IEvent
        {
            var eventTypes = _registry.GetLocalTypes(@event.GetType());

            foreach (var type in eventTypes)
            {
                var json = JsonConvert.SerializeObject(@event);
                var message = JsonConvert.DeserializeObject(json, type);

                await (Task)_dispatcher.GetType()
                    .GetMethod(nameof(_dispatcher.PublishAsync))
                    .MakeGenericMethod(type)
                    .Invoke(_dispatcher, new object[] { message});
            }
        }
    }
}
