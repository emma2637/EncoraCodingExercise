using EncoraCodingExercise.Model.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EncoraCodingExercise.Data.Contract.DB
{
   public interface IPropertyRepository
    {
        Task<List<UserViewModel>> Get();

        Task<UserViewModel> Get(int accountNumber);

        Task Save(UserViewModel user);
    }
}
