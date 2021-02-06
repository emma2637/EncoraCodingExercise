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

        public async Task<ServiceResponse<List<UserViewModel>>> Get()
        {
           
            ServiceResponse<List<UserViewModel>> response = new ServiceResponse<List<UserViewModel>>();

            try
            {
                var items = await _context.Properties.ToListAsync();

                //mapping values
                var result = new List<UserViewModel>();
                items.ForEach(x =>
                {

                    result.Add(new UserViewModel()
                    {
                        Id = x.Id,
                        AccountNumber = x.AccountNumber,
                        Address = x.Address,
                        GrossYield = x.GrossYield.ToString("#.##"),
                        ListPrice = x.ListPrice.ToString("#.##"),
                        MontlyRent = x.MontlyRent.ToString("#.##"),
                        YearBuilt = x.YearBuilt.ToString()
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
        public async Task<ServiceResponse<UserViewModel>> Get(int id)
        {
            ServiceResponse<UserViewModel> response = new ServiceResponse<UserViewModel>();
          
            try
            {
                var item = await _context.Properties.SingleOrDefaultAsync(x => x.Id == id);

                if (item == null)
                {
                    response.Success = false;
                    response.Message = "User Not Found";
                    return response;
                }

                response.Data = new UserViewModel()
                {
                    Id = item.Id,
                    AccountNumber = item.AccountNumber,
                    Address = item.Address,
                    GrossYield = item.GrossYield.ToString("#.##"),
                    ListPrice = item.ListPrice.ToString("#.##"),
                    MontlyRent = item.MontlyRent.ToString("#.##"),
                    YearBuilt = item.YearBuilt.ToString()
                };

                response.Success = true;
                response.Message = "Information get it successfully";
            }
            catch (Exception ex)
            {

                response.Success = false;
                response.Message = "Error Creating New User " + ex.Message   ;
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
                var userValidation = _context.Properties.Where(x => x.Id == user.Id);

                if (userValidation == null)
                {
                    response.Success = false;
                    response.Message = "User already Exist!";
                    return response;
                }

                var newUser = new Properties()
                {
                    AccountNumber = user.AccountNumber,
                    Address = user.Address,
                    GrossYield = Convert.ToDecimal(user.GrossYield, CultureInfo.InvariantCulture),
                    ListPrice = long.Parse(user.ListPrice, NumberStyles.Currency, CultureInfo.InvariantCulture),
                    MontlyRent = long.Parse(user.MontlyRent, NumberStyles.Currency, CultureInfo.InvariantCulture),
                    YearBuilt = long.Parse(user.YearBuilt, NumberStyles.Currency, CultureInfo.InvariantCulture)
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

        public async Task<ServiceResponse<int>> Update(UserViewModel user)
        {
            ServiceResponse<int> response = new ServiceResponse<int>();
            try
            {
                var userToUpdate = await _context.Properties.SingleOrDefaultAsync(x => x.Id == user.Id);

                if (userToUpdate == null)
                {
                    response.Success = false;
                    response.Message = "User Not Found";
                    return response;
                }

                userToUpdate = new Properties()
                {
                    AccountNumber = user.AccountNumber,
                    Address = user.Address,
                    GrossYield = Convert.ToDecimal(user.GrossYield, CultureInfo.InvariantCulture),
                    ListPrice = long.Parse(user.ListPrice, NumberStyles.Currency, CultureInfo.InvariantCulture),
                    MontlyRent = long.Parse(user.MontlyRent, NumberStyles.Currency, CultureInfo.InvariantCulture),
                    YearBuilt = long.Parse(user.YearBuilt, NumberStyles.Currency, CultureInfo.InvariantCulture)
                };
                _context.Properties.Update(userToUpdate);
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
