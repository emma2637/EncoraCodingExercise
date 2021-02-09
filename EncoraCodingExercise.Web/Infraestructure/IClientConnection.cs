using System.Net.Http;
using System.Threading.Tasks;

namespace EncoraCodingExercise.Web.Infraestructure
{
    public interface IClientConnection
    {
        Task<string> GetStringAsync(string uri);

        Task<string> PutAsync<T>(string uri, T item);
    }
}