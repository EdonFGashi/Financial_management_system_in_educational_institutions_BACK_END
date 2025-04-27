using Microsoft.Extensions.Caching.Memory;

namespace Financial_management_system_in_educational_institutions_API.Services
{
    public class CacheService
    {
        private readonly IMemoryCache _cache;

        public CacheService(IMemoryCache cache)
        {
            _cache = cache;
        }

       
        public void Set<T>(string key, T value, TimeSpan? expiration = null)
        {
            var options = new MemoryCacheEntryOptions();
            if (expiration.HasValue)
                options.SetAbsoluteExpiration(expiration.Value);

            _cache.Set(key, value, options);
        }

        public T Get<T>(string key)
        {
            _cache.TryGetValue(key, out T value);
            return value;
        }

        public void Update<T>(string key, T value, TimeSpan? expiration = null)
        {
            Remove(key);
            Set(key, value, expiration);
        }

        public void Remove(string key)
        {
            _cache.Remove(key);
        }
    }
}
