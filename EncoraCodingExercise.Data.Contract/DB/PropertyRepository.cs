using EncoraCodingExercise.Model.API;
using EncoraCodingExercise.Model.Entities;
using EncoraCodingExercise.Model.ViewModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EncoraCodingExercise.Data.Contract.DB
{
    public class PropertyRepository : IPropertyRepository
    {
        private readonly DataContext _context;

        public PropertyRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<ServiceResponse<List<UserResponseViewModel>>> Get()
        {

            ServiceResponse<List<UserResponseViewModel>> response = new ServiceResponse<List<UserResponseViewModel>>();

            try
            {
                var items = await _context.Properties.ToListAsync();

                //mapping values
                var result = new List<UserResponseViewModel>();
                items.ForEach(x =>
                {

                    result.Add(new UserResponseViewModel()
                    {
                        Id = x.Id,
                        Address = x.Address,
                        GrossYield = x.GrossYield,
                        ListPrice = x.ListPrice,
                        MontlyRent = x.MontlyRent,
                        YearBuilt = x.YearBuilt
                    });
                });


                response.Success = true;
                response.Message = "Information get it successfully";
                response.Data = result;
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = "Error Creating New User " + ex.Message;
            }


            return response;
        }
        public async Task<ServiceResponse<UserResponseViewModel>> Get(int id)
        {
            ServiceResponse<UserResponseViewModel> response = new ServiceResponse<UserResponseViewModel>();

            try
            {
                var item = await _context.Properties.SingleOrDefaultAsync(x => x.Id == id);

                if (item == null)
                {
                    response.Success = false;
                    response.Message = "User Not Found";
                    return response;
                }

                response.Data = new UserResponseViewModel()
                {
                    Id = item.Id,
                    Address = item.Address,
                    GrossYield = item.GrossYield,
                    ListPrice = item.ListPrice,
                    MontlyRent = item.MontlyRent,
                    YearBuilt = item.YearBuilt
                };

                response.Success = true;
                response.Message = "Information get it successfully";
            }
            catch (Exception ex)
            {

                response.Success = false;
                response.Message = "Error Creating New User " + ex.Message;
            }

            return response;

        }
        public async Task<ServiceResponse<int>> Save(UserViewModel user)
        {
            ServiceResponse<int> response = new ServiceResponse<int>();

            if (user == null)
            {
                response.Success = false;
                response.Message = "User Not Found";
                return response;
            }
            try
            {
                

                var newUser = new Properties()
                {
                    Address = user.Address,
                    ListPrice = user.ListPrice,
                    MontlyRent = user.MontlyRent,
                    YearBuilt = user.YearBuilt,
                    GrossYield = (user.MontlyRent * 12 / user.ListPrice)

                };

                _context.Properties.Add(newUser);
                await _context.SaveChangesAsync();

                response.Success = true;
                response.Message = "User created successfully";
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = "Fail Creating a new User property" + ex.Message;
            }
            return response;

        }

        public async Task<ServiceResponse<int>> Update(int id, UserViewModel user)
        {
            ServiceResponse<int> response = new ServiceResponse<int>();
            try
            {
                var userToUpdate = await _context.Properties.SingleOrDefaultAsync(x => x.Id == id);

                if (userToUpdate == null)
                {
                    response.Success = false;
                    response.Message = "User Not Found";
                    return response;
                }

                userToUpdate.Address = user.Address;
                userToUpdate.ListPrice = user.ListPrice;
                userToUpdate.MontlyRent = user.MontlyRent;
                userToUpdate.YearBuilt = user.YearBuilt;
                userToUpdate.GrossYield = (user.MontlyRent * 12 / user.ListPrice);

                //_context.Properties.Update(userToUpdate);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = "Fail Updating User properties" + ex.Message;
            }
            return response;

        }
    }
}
