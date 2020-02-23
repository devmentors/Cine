using System.Threading.Tasks;

namespace Cine.Shared.Modules
{
    public interface IModuleRequestClient
    {
        Task<TResult> GetAsync<TRequest, TResult>(string path, TRequest moduleRequest)
            where TRequest : class, IModuleRequest
            where TResult : class;
    }
}
