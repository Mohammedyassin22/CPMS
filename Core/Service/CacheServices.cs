using Domain.Contracts;
using ServiceAbstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class CacheServices(ICacheRepository repository) : ICacheService
    {
        public async Task<string?> GetCacheValueAsync(string key)
        {
            var value=await repository.GetAsync(key);
            return value is null ? null : value;
        }

        public async Task SetCacheValueAsync(string key, object value, TimeSpan? duration)
        {
            await repository.SetAsync(key, value, duration);
        }
    }
}
