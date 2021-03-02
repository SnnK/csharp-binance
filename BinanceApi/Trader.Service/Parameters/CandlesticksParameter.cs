using Trader.Service.Interfaces;

namespace Trader.Service.Parameters
{
    public class CandlesticksParameter : IParameter
    {
        public string Symbol { get; set; }
        public int Limit { get; set; }
        public string Interval { get; set; }
    }
}
