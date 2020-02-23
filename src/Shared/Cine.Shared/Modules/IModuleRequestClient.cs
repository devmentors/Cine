using System.Threading.Tasks;

namespace Cine.Shared.Modules
{
    public interface IModuleRequestClient
    {
        Task<TResult> GetAsync<TResult>(string path, object moduleRequest) where TResult : class;
    }
}
