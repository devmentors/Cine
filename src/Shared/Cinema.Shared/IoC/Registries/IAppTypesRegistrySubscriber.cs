using Convey.CQRS.Commands;
using Convey.CQRS.Events;
using Convey.CQRS.Queries;

namespace Cinema.Shared.IoC.Registries
{
    public interface IAppTypesRegistrySubscriber
    {
        IAppTypesRegistrySubscriber SubscribeCommand<TCommand>() where TCommand : ICommand;
        IAppTypesRegistrySubscriber SubscribeEvent<TEvent>() where TEvent : IEvent;
        IAppTypesRegistrySubscriber SubscribeQuery<TQuery, TResult>() where TQuery : IQuery<TResult>;
    }
}
