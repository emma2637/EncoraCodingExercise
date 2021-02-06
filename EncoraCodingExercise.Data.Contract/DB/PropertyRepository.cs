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

        public async Task<List<UserViewModel>> Get()
        {
            if (_context == null)
            {
                throw new NullReferenceException("No Database found");
            }

            var items = await _context.Properties.ToListAsync();

            //mapping values
            var result = new List<UserViewModel>();
            items.ForEach(x =>
            {

                result.Add(new UserViewModel()
                {
                    AccountNumber = x.AccountNumber,
                    Address = x.Address,
                    GrossYield = string.Format("{0}{1}", x.GrossYield, "%"),
                    ListPrice = string.Format("{0}{1}", "$", x.ListPrice),
                    MontlyRent = string.Format("{0}{1}", "$", x.MontlyRent),
                    YearBuilt = x.YearBuilt.ToString()
                });
            });
            return result;
        }
        public async Task<UserViewModel> Get(int accountNumber)
        {
            if (_context == null)
            {
                throw new NullReferenceException("No Database found");
            }

            var item = await _context.Properties.SingleOrDefaultAsync(x => x.AccountNumber == accountNumber);

            return new UserViewModel()
            {
                AccountNumber = item.AccountNumber,
                Address = item.Address,
                GrossYield = string.Format("{0}{1}", item.GrossYield, "%"),
                ListPrice = string.Format("{0}{1}", "$", item.ListPrice),
                MontlyRent = string.Format("{0}{1}", "$", item.MontlyRent),
                YearBuilt = item.YearBuilt.ToString()
            }; 
        }


        public async Task Save(UserViewModel user)
        {
            if (user == null)
            {
                throw new ArgumentNullException("User can not be null");
            }
            try
            {
                var userValidation = _context.Properties.Where(x => x.AccountNumber == user.AccountNumber);

                if (userValidation == null)
                {
                    throw new ArgumentNullException("User already exists");
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
            }
            catch (Exception)
            {
                throw;
            }
        }

      
    }
}
