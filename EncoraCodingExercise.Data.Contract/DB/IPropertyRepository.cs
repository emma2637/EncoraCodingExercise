using EncoraCodingExercise.Model.API;
using EncoraCodingExercise.Model.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EncoraCodingExercise.Data.Contract.DB
{
   public interface IPropertyRepository
    {
        Task<ServiceResponse<List<UserResponseViewModel>>> Get();

        Task<ServiceResponse<UserResponseViewModel>> Get(int id);


        Task<ServiceResponse<int>> Save(UserViewModel user);

        Task<ServiceResponse<int>> Update(int id, UserViewModel user);


    }
}
