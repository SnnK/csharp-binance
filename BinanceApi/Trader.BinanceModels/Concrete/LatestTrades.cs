using Trader.BinanceModels.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Trader.BinanceModels.Concrete
{
    public class LatestTradesWrapper
    {
        public decimal Total_both { get; set; }
        public decimal Total_BuyerMakerTrue { get; set; }
        public decimal Total_BuyerMakerFalse { get; set; }
        public List<LatestTrades> LatestTrades { get; set; }
    }

    public class LatestTrades : IBinanceApi
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("price")]
        public decimal Price { get; set; }

        [JsonProperty("qty")]
        public decimal Qty { get; set; }

        [JsonProperty("quoteQty")]
        public decimal QuoteQty { get; set; }

        [JsonProperty("time")]
        public long Time { get; set; }

        [JsonProperty("isBuyerMaker")]
        public bool IsBuyerMaker { get; set; }

        [JsonProperty("isBestMatch")]
        public bool IsBestMatch { get; set; }
        public DateTime TimeReadable => DateTimeOffset.FromUnixTimeMilliseconds(Time).DateTime;
    }
}
