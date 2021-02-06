using EncoraCodingExercise.Model.ViewModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
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

        public async Task<List<PropertiesResponse>> Get()
        {
            if(_context == null)
            {
                throw new NullReferenceException("No Database found");
            }

            var items = await _context.Properties.ToListAsync();

            //mapping values
            var result = new List<PropertiesResponse>();
            items.ForEach(x => {

                result.Add(new PropertiesResponse() { 
                AccountNumber = x.AccountNumber,
                Address = x.Address,
                GrossYield = string.Format("{0}{1}",x.GrossYield,"%"),
                ListPrice = string.Format("{0}{1}","$",x.ListPrice),
                MontlyRent= string.Format("{0}{1}","$",x.MontlyRent),
                YearBuilt = x.YearBuilt.ToString()
                });
            });
            return result;
        }

    }
}
