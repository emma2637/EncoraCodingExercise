using EncoraCodingExercise.Model.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EncoraCodingExercise.Data.Contract.API
{
    public interface IRequestHandlerRepository
    {
        Task<IEnumerable<PropertiesResponse>> GetPropertiesAsync();
    }
}