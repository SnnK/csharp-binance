using Trader.BinanceModels.Interfaces;
using JsonConverters.Helper;
using Newtonsoft.Json;

namespace Trader.BinanceModels.Concrete
{
    [JsonConverter(typeof(ObjectToArrayConverter<Order>))]
    public class Order : IBinanceApi
    {
        [JsonProperty(Order = 1)]
        public decimal Price { get; set; }

        [JsonProperty(Order = 2)]
        public decimal Quantity { get; set; }

        [JsonIgnore]
        public decimal Total { get; set; }
    }
}
