using EncoraCodingExercise.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EncoraCodingExercise.Web.Services
{
    public interface IPropertyService
    {
        Task<UserPropertyViewModel> GetAllItems();
    }
}
