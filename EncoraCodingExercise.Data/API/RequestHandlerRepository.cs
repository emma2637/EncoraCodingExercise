using EncoraCodingExercise.Model.ViewModels;
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using static EncoraCodingExercise.Model.Properties;

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

        public async Task<IEnumerable<PropertiesResponse>> GetPropertiesAsync()
        {

            var PropertyList = await GetInfoProperties();
            var result = new List<PropertiesResponse>();

            PropertyList.ToList().ForEach(x =>
            {
                result.Add(new PropertiesResponse()
                {
                    AccountNumber = x.accountId,
                    Address =   x.address != null ? x.address.address1 : "",
                    YearBuilt = x.physical != null ? x.physical.yearBuilt.ToString() : "", //format two decimal places eg 120,000.00
                    ListPrice = x.financial != null ? x.financial.listPrice.ToString() : "",
                    MontlyRent = x.financial != null ? x.financial.monthlyRent.ToString() : "",
                    GrossYield = x.financial != null ? string.Format("{0} {1}", (x.financial.monthlyRent * 12 / x.financial.listPrice), "%") : ""
                }); ;
            });
            return result;
        }
    }
}
