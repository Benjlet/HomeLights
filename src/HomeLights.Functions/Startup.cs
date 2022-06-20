using HomeLights.Functions;
using HueManatee.Extensions;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Net.Http;

[assembly: FunctionsStartup(typeof(Startup))]
namespace HomeLights.Functions
{
    public class Startup : FunctionsStartup
    {
        private const string HueBridgeIgnoreCertsConfig = "HueBridgeIgnoreCerts";
        private const string HueBridgeIpAddressConfig = "HueBridgeIpAddress";
        private const string HueBridgeUserNameConfig = "HueBridgeUserName";

        public override void Configure(IFunctionsHostBuilder builder)
        {
            var ipAddress = Environment.GetEnvironmentVariable(HueBridgeIpAddressConfig);
            var userName = Environment.GetEnvironmentVariable(HueBridgeUserNameConfig);
            var ignoreCerts = bool.Parse(Environment.GetEnvironmentVariable(HueBridgeIgnoreCertsConfig) ?? string.Empty);

            builder.Services.AddBridgeClient(ipAddress, userName);
            builder.Services.AddSingleton<ICryptoPriceTracker, CryptoPriceTracker>();
            builder.Services.AddSingleton<ICryptoDataClient, CoinGeckoClient>(sp =>
                new CoinGeckoClient(sp.GetRequiredService<IHttpClientFactory>()));
        }
    }
}