using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace MarsRoverPhotoSearchAPI.Helpers
{
    public static class HttpResponseMessageExtensions
    {
        public static async Task<PhotoGallery> Parse(this HttpResponseMessage response)
        {
            if (response != null && response.IsSuccessStatusCode)
            {
                var jsonString = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<PhotoGallery>(jsonString);               
            }
            return null;
        }
    }
}
