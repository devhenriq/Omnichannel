using Customers.Domain.Aggregates.Addresses;
using Customers.Infrastructure.Providers.Cep;
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;

namespace Customers.Infrastructure.Repositories
{
    public class AddressRepository : IAddressRepository
    {
        private readonly IDistributedCache _cache;
        private readonly IViaCepClient _viaCepClient;

        public AddressRepository(IDistributedCache cache, IViaCepClient viaCepClient)
        {
            _cache = cache;
            _viaCepClient = viaCepClient;
        }

        public async Task<Address> GetAddressAsync(string zipCode)
        {
            var address = GetFromCache<Address>(zipCode);
            if (address == null)
            {
                var viaCepResponse = await _viaCepClient.GetAddressAsync(zipCode);
                address = viaCepResponse.ToDomain();
                SetOnCache(zipCode, address);
            }

            return address;
        }

        private T? GetFromCache<T>(string key)
        {
            var cachedObject = _cache.GetString(key);
            if (cachedObject is null) return default;
            return JsonConvert.DeserializeObject<T>(cachedObject);
        }

        private void SetOnCache<T>(string key, T objectToCache)
        {
            var cacheOptions = new DistributedCacheEntryOptions()
            {
                AbsoluteExpirationRelativeToNow = TimeSpan.FromHours(20)
            };

            _cache.SetString(key, JsonConvert.SerializeObject(objectToCache), cacheOptions);
        }
    }
}
