using Trader.BussinessProcess.Interfaces;

namespace Trader.BussinessProcess.Parameters
{
    public class OrderBookParameter : IParameter
    {
        public string Symbol { get; set; }
        public int Limit { get; set; }
    }
}
