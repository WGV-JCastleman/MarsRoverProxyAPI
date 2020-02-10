using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Linq;

namespace MarsRoverPhotoSearchAPI.Helpers
{
    public class ApiProxyClient
    {
        private readonly string baseApiEndpoint;
        private readonly string nasaApiKey;
        private readonly bool cacheFirst;
        //private readonly bool enforRettryes;


        public ApiProxyClient(string baseUrl, string apiKey, bool enforceCacheFirstCheck = false)
        {
            if(!string.IsNullOrEmpty(baseUrl) && !string.IsNullOrEmpty(apiKey))
            {
                baseApiEndpoint = baseUrl;
                nasaApiKey = apiKey;
                cacheFirst = enforceCacheFirstCheck;
            }
        }

        [Produces("application/json")]
        public async Task<HttpResponseMessage> GetAsync(string date, string rover="curiosity", string camera = null)
        {
            var url = BuildRquestUrl(date, rover, camera);

            using var httpClient = new HttpClient();
            return  await httpClient.GetAsync(url);
        }

        private string BuildRquestUrl(string date, string rover, string camera = null)
        {
            if(string.IsNullOrEmpty(date))
            {
                return $"{baseApiEndpoint}rovers/{rover}/photos?earth_date={date}&camera={camera}&api_key={nasaApiKey}";
            }
            return $"{baseApiEndpoint}rovers/{rover}/photos?earth_date={date}&api_key={nasaApiKey}";
        }
    }
}






