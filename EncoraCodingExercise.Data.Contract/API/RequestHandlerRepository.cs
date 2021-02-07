using EncoraCodingExercise.Model;
using EncoraCodingExercise.Model.Entities;
using EncoraCodingExercise.Model.ViewModels;
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using static EncoraCodingExercise.Model.PropertiesOriginalData;

namespace EncoraCodingExercise.Data.Contract.API
{
    public class RequestHandlerRepository : IRequestHandlerRepository
    {
        private async Task<IEnumerable<Property>> GetInfoProperties()
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    //change url way to get it from app.config
                    var url = new Uri("https://samplerspubcontent.blob.core.windows.net/public/properties.json");
                    var getUri = client.GetAsync(url);
                    var json = await getUri.Result.Content.ReadAsStringAsync();
                    var result = JsonConvert.DeserializeObject<Rootobject>(json);
                    return result.properties;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public async Task<IEnumerable<Properties>> GetPropertiesAsync()
        {
            var PropertyList = await GetInfoProperties();
            var result = new List<Properties>();

            PropertyList.ToList().ForEach(x =>
            {
                result.Add(new Properties()
                {
                    AccountNumber = x.accountId,
                    Address =   x.address != null ? x.address.address1 : "",
                    YearBuilt = x.physical != null ? x.physical.yearBuilt : 0, //format two decimal places eg 120,000.00
                    ListPrice = x.financial != null ? (long)x.financial.listPrice : 0,
                    MontlyRent = x.financial != null ? (long)x.financial.monthlyRent : 0,
                    //GrossYield = x.financial != null ? string.Format("{0} {1}", (x.financial.monthlyRent * 12 / x.financial.listPrice), "%") : 0.0M
                    GrossYield = x.financial != null ? (decimal)(x.financial.monthlyRent * 12 / x.financial.listPrice)*100 : 0//multiply by 100
                }); ;
            });

            return result;
        }
    }
}
