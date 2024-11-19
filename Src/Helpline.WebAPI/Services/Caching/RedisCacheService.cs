using Microsoft.Extensions.Caching.Distributed;
using System.Text.Json;

namespace Helpline.WebAPI.Services.Caching
{
    public class RedisCacheService : IRedisCacheService
    {
        private readonly IDistributedCache cache;

        public RedisCacheService(IDistributedCache cache)
        {
            this.cache = cache;
        }

        public T? GetData<T>(string key)
        {
            var data = cache.GetString(key);

            if (data == null)
                return default;

            return JsonSerializer.Deserialize<T>(data);
        }

        public void SetData<T>(string key, T value)
        {
            var options = new DistributedCacheEntryOptions
            {
                AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(5),
            };

            cache.SetString(key, JsonSerializer.Serialize(value), options);
        }
    }
}
