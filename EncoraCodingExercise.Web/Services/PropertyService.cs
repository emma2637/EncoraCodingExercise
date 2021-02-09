using EncoraCodingExercise.Web.Infraestructure;
using EncoraCodingExercise.Web.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EncoraCodingExercise.Web.Services
{
    public class PropertyService:IPropertyService
    {
        private readonly IConfiguration _configuration;
        private readonly IClientConnection _apiClient;
        private readonly ILogger<PropertyService> _logger;

        public string ApiBaseUrl { get; set; }

        public PropertyService(IConfiguration configuration,IClientConnection clientConnection, ILogger<PropertyService> logger)
        {
            _configuration = configuration;
            _apiClient = clientConnection;
            _logger = logger;
            ApiBaseUrl = _configuration.GetValue<string>("WebAPIBaseUrl");
        }

        public async Task<UserPropertyViewModel> GetAllItems()
        {
            var uri = ApiPaths.GetAllUserProperties(ApiBaseUrl);
        
            var dataString = await _apiClient.GetStringAsync(uri);

            var response = JsonConvert.DeserializeObject<UserPropertyViewModel>(dataString);

            return response;
        }
        public async Task<UserPropertyViewModel> Save(ResponseViewModel model)
        {
            var uri = ApiPaths.UpdateProperty(ApiBaseUrl,model.Id);

            var dataString = await _apiClient.PutAsync(uri,model);

            var response = JsonConvert.DeserializeObject<UserPropertyViewModel>(dataString);

            return response;
        }
    }
}
