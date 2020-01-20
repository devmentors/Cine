using System.Threading.Tasks;

namespace Cine.Shared.IoC.Modules
{
    public interface IModuleRequestDispatcher
    {
        Task<TResult> RequestAsync<TRequest, TResult>(TRequest request) where TRequest : class, IModuleRequest<TResult> where TResult : class;
    }
}
