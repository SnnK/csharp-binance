using Trader.BussinessProcess.Interfaces;

namespace Trader.BussinessProcess.Parameters
{
    public class ExchangeInfoParameter : IParameter
    {
        public string Base { get; set; }
        public string Quote { get; set; }
    }
}
