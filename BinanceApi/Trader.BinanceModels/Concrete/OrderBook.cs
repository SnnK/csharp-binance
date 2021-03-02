using Trader.BinanceModels.Interfaces;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Trader.BinanceModels.Concrete
{
    public class OrderBook : IBinanceApi
    {
        [JsonIgnore]
        public decimal TotalAsks { get; set; }

        [JsonIgnore]
        public decimal TotalBids { get; set; }

        [JsonProperty("lastUpdateId")]
        public long LastUpdateId { get; set; }

        [JsonProperty("Bids")]
        public List<Order> Bids { get; set; }

        [JsonProperty("Asks")]
        public List<Order> Asks { get; set; }
    }
}
