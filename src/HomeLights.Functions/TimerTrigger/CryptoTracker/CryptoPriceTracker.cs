using System.Collections.Concurrent;

namespace HomeLights.Functions
{
    public class CryptoPriceTracker : ICryptoPriceTracker
    {
        private readonly ConcurrentDictionary<string, CryptoPrice> _cryptoData;

        public CryptoPriceTracker()
        {
            _cryptoData = new ConcurrentDictionary<string, CryptoPrice>();
        }

        public double? GetLastValue(string name) => _cryptoData[name]?.LatestValue;
        public double? GetPriceChange(string name)
        {
            return _cryptoData.ContainsKey(name) ? (_cryptoData[name].LatestValue - _cryptoData[name].InitialValue) : null;
        }

        public bool AddCurrentValue(string name, double currentValue)
        {
            bool isIncrease = true;

            _cryptoData.AddOrUpdate(name,
              id => new CryptoPrice()
              {
                  InitialValue = currentValue,
                  LatestValue = currentValue
              },
              (id, v) =>
              {
                  isIncrease = currentValue > v.LatestValue;
                  v.LatestValue = currentValue;
                  return v;
              });

            return isIncrease;
        }
    }
}
