using Trader.BinanceModels.Enums;
using Trader.BinanceModels.Interfaces;
using Newtonsoft.Json;

namespace Trader.BinanceModels.Concrete
{
    public class OrderResponse : IBinanceApi
    {
        [JsonProperty("symbol")]
        public string Symbol { get; set; }

        [JsonProperty("orderId")]
        public long OrderId { get; set; }

        [JsonProperty("orderListId")]
        public long OrderListId { get; set; }

        [JsonProperty("clientOrderId")]
        public string ClientOrderId { get; set; }

        [JsonProperty("transactTime")]
        public long TransactTime { get; set; }

        [JsonProperty("price")]
        public string Price { get; set; }

        [JsonProperty("origQty")]
        public string OrigQty { get; set; }

        [JsonProperty("executedQty")]
        public string ExecutedQty { get; set; }

        [JsonProperty("cummulativeQuoteQty")]
        public string CummulativeQuoteQty { get; set; }

        [JsonProperty("status")]
        public OrderStatus Status { get; set; }

        [JsonProperty("timeInForce")]
        public TimeInForce TimeInForce { get; set; }

        [JsonProperty("type")]
        public OrderType Type { get; set; }

        [JsonProperty("side")]
        public Side Side { get; set; }

        [JsonProperty("fills")]
        public object[] Fills { get; set; }
    }
}
