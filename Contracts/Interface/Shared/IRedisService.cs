using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.Interface.Shared
{
    public interface IRedisService<T> where T : class
    {
        public Task<List<T>> getListFromRedis(string cachedKey);
        public Task<T> getObjectFromRedis(string cachedKey);
        public Task setToRedis(List<T> list, string cachedKey);
        public Task setToRedis(T obj, string cachedKey);
        public Task clearCache(string cachedKey);

    }
}
