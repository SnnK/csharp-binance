using Trader.Service.Interfaces;

namespace Trader.Service.Parameters
{
    public class ExchangeInfoParameter : IParameter
    {
        public string Base { get; set; }
        public string Quote { get; set; }
    }
}
