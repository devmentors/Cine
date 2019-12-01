using System;
using Convey.CQRS.Commands;
using Convey.CQRS.Events;
using Convey.CQRS.Queries;

namespace Cinema.Shared.IoC.Registries
{
    internal sealed class AppTypesRegistrySubscriber : IAppTypesRegistrySubscriber
    {
        private readonly IAppTypesRegistry _registry;

        public AppTypesRegistrySubscriber(IAppTypesRegistry registry)
            => _registry = registry;

        public IAppTypesRegistrySubscriber SubscribeCommand<TCommand>() where TCommand : ICommand
            => RegisterType<TCommand>();

        public IAppTypesRegistrySubscriber SubscribeEvent<TEvent>() where TEvent : IEvent
            => RegisterType<TEvent>();

        public IAppTypesRegistrySubscriber SubscribeQuery<TQuery, TResult>() where TQuery : IQuery<TResult>
        {
            RegisterType<TQuery>();
            RegisterType<TResult>();
            return this;
        }

        private IAppTypesRegistrySubscriber RegisterType<T>()
        {
            var type = typeof(T);
            var isSucceed = _registry.TryAdd(type);

            if (!isSucceed)
            {
                throw new InvalidOperationException($"Cannot register {type.FullName} in app types registry");
            }

            return this;
        }
    }
}
