using Trader.Service.Interfaces;

namespace Trader.Service.Parameters
{
    public class MyTradesParameter : IParameter
    {
        public string Symbol { get; set; }
        public int Limit { get; set; }
    }
}
