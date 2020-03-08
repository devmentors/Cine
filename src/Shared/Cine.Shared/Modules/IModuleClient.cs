using System.Threading.Tasks;

namespace Cine.Shared.Modules
{
    public interface IModuleClient
    {
        Task<TResult> GetAsync<TResult>(string path, object moduleRequest) where TResult : class;
        Task PublishAsync(object moduleBroadcast);
    }
}
