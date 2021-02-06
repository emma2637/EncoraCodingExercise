using EncoraCodingExercise.Model.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EncoraCodingExercise.Data.Contract.API
{
    public interface IRequestHandlerRepository
    {
        Task<IEnumerable<Properties>> GetPropertiesAsync();
    }
}