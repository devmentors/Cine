using System.Threading.Tasks;

namespace Cine.Shared.IoC.Modules
{
    public interface IModuleRequestHandler<in TRequest, TResult> where TRequest : class, IModuleRequest where TResult : class
    {
        Task<TResult> HandleAsync(TRequest request);
    }
}
