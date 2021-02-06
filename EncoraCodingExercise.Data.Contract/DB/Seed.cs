using EncoraCodingExercise.Data.Contract.API;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;

namespace EncoraCodingExercise.Data.Contract.DB
{
   public static class Seed
    {
        private static IRequestHandlerRepository _requestHandlerRepository;

        public static async Task SeedAsync(DataContext context)
        {
           context.Database.EnsureCreated();
           
                _requestHandlerRepository = new RequestHandlerRepository();
                var result = _requestHandlerRepository.GetPropertiesAsync().Result;

                if (!context.Properties.Any())
                {
                    await context.AddRangeAsync(result);
                    await context.SaveChangesAsync();
                }
        }
    }
}
