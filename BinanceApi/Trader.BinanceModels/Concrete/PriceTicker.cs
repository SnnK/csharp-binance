using Trader.BinanceModels.Interfaces;
using Newtonsoft.Json;

namespace Trader.BinanceModels.Concrete
{
    public class PriceTicker : IBinanceApi
    {
        [JsonProperty("symbol")]
        public string Symbol { get; set; }

        [JsonProperty("price")]
        public decimal Price { get; set; }
    }
}
