using System.Threading.Tasks;

namespace HomeLights.Functions
{
    public interface ICryptoDataClient
    {
        Task<MarketData> GetPriceData(string currency, string id);
    }
}
