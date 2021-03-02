using Trader.BinanceModels.Interfaces;

namespace Trader.BinanceModels.Concrete
{
    public class ApiError : IBinanceApi
    {
        public int Code { get; set; }
        public string Msg { get; set; }
    }
}
