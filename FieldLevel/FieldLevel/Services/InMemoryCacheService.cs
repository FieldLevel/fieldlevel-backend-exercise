using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FieldLevel.Services {
    public class InMemoryCacheService : ICacheService {
        private IMemoryCache _cache;
        public InMemoryCacheService(IMemoryCache cache) {
            this._cache = cache;
        }
        public T GetOrSet<T>(string cacheKey, TimeSpan duration, Func<T> getItemCallback) where T : class {
            T item = _cache.Get(cacheKey) as T;
            if (item == null) {
                item = getItemCallback();
                _cache.Set(cacheKey, item, duration);
            }
            return item;
        }

        public void Clear(string cacheKey) {
            _cache.Remove(cacheKey);
        }
    }
}
