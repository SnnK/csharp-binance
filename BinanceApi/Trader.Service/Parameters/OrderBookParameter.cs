using Trader.Service.Interfaces;

namespace Trader.Service.Parameters
{
    public class OrderBookParameter : IParameter
    {
        public string Symbol { get; set; }
        public int Limit { get; set; }
    }
}
