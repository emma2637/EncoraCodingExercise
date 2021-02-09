
using EncoraCodingExercise.Model.API;
using EncoraCodingExercise.Model.ViewModels;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace EncoraCodingExercise.Web.Infraestructure
{
    public class ClientConnection : IClientConnection
    {
        private HttpClient _client;
        private ILogger<ClientConnection> _logger;

        public ClientConnection(ILogger<ClientConnection> logger)
        {
            _client = new HttpClient();
            _logger = logger;
        }

        public async Task<string> GetStringAsync(string uri)
        {
            var requestMessage = new HttpRequestMessage(HttpMethod.Get, uri);
                //var result = JsonConvert.DeserializeObject<>(json);

            var response = await _client.SendAsync(requestMessage);


            // var responseResult = JsonConvert.DeserializeObject<>(response);

            return await response.Content.ReadAsStringAsync(); 
        }

        public async Task<HttpResponseMessage> PostAsync<T>(string uri, T item)
        {
            return await DoPostPutAsync(HttpMethod.Post, uri, item);
        }

        public async Task<string> PutAsync<T>(string uri, T item)
        {

            //var requestMessage = new HttpRequestMessage(HttpMethod.Put, uri)
            //{
            //    Content = new StringContent(JsonConvert.SerializeObject(item), System.Text.Encoding.UTF8, "application/json")
            //};

            //var response = await _client.SendAsync(requestMessage);

            //return await response.Content.ReadAsStringAsync();


            var requestMessage = new HttpRequestMessage(HttpMethod.Put, uri)
            {
                Content = new StringContent(JsonConvert.SerializeObject(item), System.Text.Encoding.UTF8, "application/json")
            };

            var response = await _client.PutAsync(uri, requestMessage.Content);

            return response.ToString();


        }

        private async Task<HttpResponseMessage> DoPostPutAsync<T>(HttpMethod method, string uri, T item)
        {
            if (method != HttpMethod.Post && method != HttpMethod.Put)
            {
                throw new ArgumentException("Value must be either post or put.", nameof(method));
            }

            // a new StringContent must be created for each retry 
            // as it is disposed after each call

            var requestMessage = new HttpRequestMessage(HttpMethod.Post, uri)
            {
                Content = new StringContent(JsonConvert.SerializeObject(item), System.Text.Encoding.UTF8, "application/json")
            };

            var response = await _client.SendAsync(requestMessage);

            // raise exception if HttpResponseCode 500 
            // needed for circuit breaker to track fails

            if (response.StatusCode == HttpStatusCode.InternalServerError)
            {
                throw new HttpRequestException();
            }

            return response;
        }

    }
}
