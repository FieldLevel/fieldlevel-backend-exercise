using System;

namespace FieldLevel.Services {
    /// <summary>
    /// Generic interface for storing result sets.
    /// </summary>
    public interface ICacheService {
        T GetOrSet<T>(string cacheKey, TimeSpan duration, Func<T> getItemCallback) where T : class;
        void Clear(string cacheKey);
    }
}
