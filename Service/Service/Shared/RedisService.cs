using Contracts.Interface.Shared;
using Microsoft.Extensions.Caching.Distributed;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Service.Service.Shared
{
    public class RedisService<T> : IRedisService<T> where T : class
    {
        private readonly IDistributedCache _distributedCache;
        public RedisService(IDistributedCache distributedCache)
        {
            _distributedCache = distributedCache;
        }
        public async Task setToRedis(List<T> list, string cachedKey)
        {
            string cachedStr = JsonSerializer.Serialize<List<T>>(list);
            await _distributedCache.SetStringAsync(cachedKey, cachedStr);
        }
        public async Task setToRedis(T obj, string cachedKey)
        {
            string cachedStr = JsonSerializer.Serialize<T>(obj);
            await _distributedCache.SetStringAsync(cachedKey, cachedStr);
        }
        public async Task<List<T>> getListFromRedis(string cachedKey)
        {
            string cachedStr = await _distributedCache.GetStringAsync(cachedKey);
            if (!string.IsNullOrEmpty(cachedStr))
                return JsonSerializer.Deserialize<List<T>>(cachedStr);
            else
                return null;
        }
        public async Task<T> getObjectFromRedis(string cachedKey)
        {
            string cachedStr = await _distributedCache.GetStringAsync(cachedKey);
            if (!string.IsNullOrEmpty(cachedStr))
                return JsonSerializer.Deserialize<T>(cachedStr);
            else
                return null;
        }
        public async Task clearCache(string cachedKey)
        {
            await _distributedCache.RemoveAsync(cachedKey);

        }
    }
}

