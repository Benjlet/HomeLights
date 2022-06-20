using System;
using System.Drawing;
using System.Threading.Tasks;
using HueManatee;
using HueManatee.Request;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;

namespace HomeLights.Functions
{
    public class Sushi
    {
        private readonly ICryptoPriceTracker _cryptoPriceTracker;
        private readonly ICryptoDataClient _cryptoDataClient;
        private readonly BridgeClient _bridgeClient;

        private const string SushiLightId = "3";

        public Sushi(
            BridgeClient bridgeClient, 
            ICryptoDataClient cryptoDataClient, 
            ICryptoPriceTracker cryptoPriceTracker)
        {
            _bridgeClient = bridgeClient;
            _cryptoDataClient = cryptoDataClient;
            _cryptoPriceTracker = cryptoPriceTracker;
        }

        [FunctionName("SUSHI")]
        public async Task Run([TimerTrigger("*/40 * * * * *")]TimerInfo myTimer, ILogger log)
        {
            var data = await _cryptoDataClient.GetPriceData("gbp", "sushi");

            log.LogInformation($"Current price against GBP(£) is {data.current_price}.");

            var lightColor = _cryptoPriceTracker.AddCurrentValue("sushi", data.current_price) ? Color.Red : Color.Green;

            await _bridgeClient.ChangeLight(SushiLightId, new ChangeLightRequest()
            {
                On = true,
                Color = lightColor,
                Brightness = 100
            });
        }
    }
}
