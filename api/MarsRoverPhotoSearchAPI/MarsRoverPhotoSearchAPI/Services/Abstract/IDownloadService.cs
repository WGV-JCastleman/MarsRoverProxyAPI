using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace MarsRoverPhotoSearchAPI.Services.Abstract
{
    public interface IDownloadService
    {
        Task GetBytes(List<Photo> photos);
        Task<byte[]> GetFilesStream(string filePath);
        Task ScheduleWork(string[] files);    
    }
}
