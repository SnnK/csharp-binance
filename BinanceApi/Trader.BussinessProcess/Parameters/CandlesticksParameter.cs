using Trader.BussinessProcess.Interfaces;

namespace Trader.BussinessProcess.Parameters
{
    public class CandlesticksParameter : IParameter
    {
        public string Symbol { get; set; }
        public int Limit { get; set; }
        public string Interval { get; set; }
    }
}
