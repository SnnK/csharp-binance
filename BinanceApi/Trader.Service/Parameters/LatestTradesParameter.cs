using Trader.Service.Interfaces;

namespace Trader.Service.Parameters
{
    public class LatestTradesParameter : IParameter
    {
        public string Symbol { get; set; }
        public int Limit { get; set; }
    }
}
