using System;
using System.Collections.Concurrent;
using System.Net;
using System.Threading.Tasks;
using System.Collections.Generic;
using MarsRoverPhotoSearchAPI.Helpers;
using MarsRoverPhotoSearchAPI.Services.Abstract;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace MarsRoverPhotoSearchAPI.Services.Concrete
{
    public class DownloadService : IDownloadService
    {
        public readonly IConfiguration _workerConfiguration;

        private ApiProxyClient _httpProxyClient;
        private readonly ConcurrentQueue<string> downloadedFilesQueue = new ConcurrentQueue<string>();
        
        public DownloadService(IConfiguration config)
        {
            _workerConfiguration = config;
            _httpProxyClient = new ApiProxyClient(_workerConfiguration.GetValue<string>("NASA_API_BASE_ENDPOINT"), _workerConfiguration.GetValue<string>("API_KEY"));
        }

        public async Task GetBytes(List<Photo> photos)
        {
            foreach(var photo in photos)
            {
                using var webClient = new WebClient();
                if (!string.IsNullOrEmpty(photo.img_src))
                {
                    var fileSplit = photo.img_src.Split(new[] { '/' });
                    var filename = fileSplit[fileSplit.Length - 1];
                    await webClient.DownloadFileTaskAsync(new Uri(photo.img_src), filename).ContinueWith(t =>
                    {
                        //save into memCache

                        //add to file queue
                        downloadedFilesQueue.Enqueue(filename);
                    });
                }
            }
        }

        public async Task<byte[]> GetFilesStream()
        {
            if (!downloadedFilesQueue.IsEmpty)
            {
                var success = downloadedFilesQueue.TryDequeue(out string filename);
                if (success)
                {
                    var imageBytes =  await File.ReadAllBytesAsync(filename);
                    return imageBytes;
                }
            }

            return null;
        }

        public async Task ScheduleWork(string[] dates)
        {
            foreach(var dateStr in dates)
            {
               var photoColl =  await _httpProxyClient.GetAsync(dateStr).Result.Parse();
               //Attempt to Get Bytes from the photos
               if(photoColl != null)
                {
                    await GetBytes(photoColl.Photos);
                }
            }
        }

    }
}
