namespace HomeLights.Functions
{
    public interface ICryptoPriceTracker
    {
        public double? GetLastValue(string name);
        public double? GetPriceChange(string name);
        public bool AddCurrentValue(string name, double currentValue);
    }
}
