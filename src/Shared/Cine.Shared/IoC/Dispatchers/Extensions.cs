using Convey;
using Convey.CQRS.Events;
using Microsoft.Extensions.DependencyInjection;

namespace Cine.Shared.IoC.Dispatchers
{
    public static class Extensions
    {
        public static IConveyBuilder AddAppTypesEventDispatcher(this IConveyBuilder builder)
        {
            builder.Services.Decorate<IEventDispatcher, AppTypesEventDispatcherDecorator>();
            return builder;
        }
    }
}
