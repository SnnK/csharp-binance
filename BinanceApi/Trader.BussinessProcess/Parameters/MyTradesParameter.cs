using Trader.BussinessProcess.Interfaces;

namespace Trader.BussinessProcess.Parameters
{
    public class MyTradesParameter : IParameter
    {
        public string Symbol { get; set; }
        public int Limit { get; set; }
    }
}
