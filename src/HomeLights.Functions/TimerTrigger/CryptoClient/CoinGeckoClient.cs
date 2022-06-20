using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace HomeLights.Functions
{
    internal class CoinGeckoClient : ICryptoDataClient
    {
        private readonly IHttpClientFactory _httpClientFactory;

        internal CoinGeckoClient(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<MarketData> GetPriceData(string currency, string id)
        {
            var httpClient = _httpClientFactory.CreateClient("CoinGeckoClient");
            
            var url = $"https://api.coingecko.com/api/v3/coins/markets?vs_currency={currency}&ids={id}";

            var result = await httpClient.GetAsync(url);
            var resultJson = await result.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<List<MarketData>>(resultJson).FirstOrDefault();
        }
    }
}
