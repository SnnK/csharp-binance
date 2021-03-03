using Trader.BussinessProcess.Interfaces;

namespace Trader.BussinessProcess.Parameters
{
    public class LatestTradesParameter : IParameter
    {
        public string Symbol { get; set; }
        public int Limit { get; set; }
    }
}
