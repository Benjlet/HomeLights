namespace HomeLights.Functions
{
    public class MarketData
    {
        public string id { get; set; }
        public string symbol { get; set; }
        public string name { get; set; }
        public string image { get; set; }
        public double current_price { get; set; }
        public string market_cap { get; set; }
        public string market_cap_rank { get; set; }
        public string fully_diluted_valuation { get; set; }
        public string total_volume { get; set; }
        public string high_24h { get; set; }
        public string low_24h { get; set; }
        public string price_change_24h { get; set; }
        public double price_change_percentage_24h { get; set; }
        public string market_cap_change_24h { get; set; }
        public string market_cap_change_percentage_24h { get; set; }
        public string circulating_supply { get; set; }
        public string total_supply { get; set; }
        public string max_supply { get; set; }
        public string ath { get; set; }
        public string ath_change_percentage { get; set; }
        public string ath_date { get; set; }
        public string atl { get; set; }
        public string atl_change_percentage { get; set; }
        public string atl_date { get; set; }
        public string roi { get; set; }
        public string last_updated { get; set; }
    }
}
