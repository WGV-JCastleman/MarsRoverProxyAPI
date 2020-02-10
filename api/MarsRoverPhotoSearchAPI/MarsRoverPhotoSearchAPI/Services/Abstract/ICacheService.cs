using System;
using System.Threading.Tasks;

namespace MarsRoverPhotoSearchAPI.Services.Abstract
{
    public interface ICacheService
    {
        Task InsertToCache(string key, byte[] stream, out Exception error);
        Task RemoveFromCache(string key, out Exception error);
        Task<byte[]> Get(string key, out Exception error);
    }
}
