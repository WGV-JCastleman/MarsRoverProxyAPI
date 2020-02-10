using System;
using System.Threading.Tasks;
using MarsRoverPhotoSearchAPI.Services.Abstract;

namespace MarsRoverPhotoSearchAPI.Services.Concrete
{
    public class CacheService : ICacheService
    {
        public CacheService()
        {
        }

        public Task<byte[]> Get(string key, out Exception error)
        {
            throw new NotImplementedException();
        }

        public Task InsertToCache(string key, byte[] stream, out Exception error)
        {
            throw new NotImplementedException();
        }

        public Task RemoveFromCache(string key, out Exception error)
        {
            throw new NotImplementedException();
        }
    }
}
