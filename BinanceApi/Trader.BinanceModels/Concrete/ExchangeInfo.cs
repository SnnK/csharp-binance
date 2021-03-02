using Trader.BinanceModels.Interfaces;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Trader.BinanceModels.Concrete
{
    public class ExchangeInfo : IBinanceApi
    {
        [JsonProperty("timezone")]
        public string Timezone { get; set; }

        [JsonProperty("serverTime")]
        public long ServerTime { get; set; }

        [JsonProperty("symbols")]
        public List<Symbol> Symbols { get; set; }
    }

    public class Symbol
    {
        [JsonProperty("symbol")]
        public string SymbolSymbol { get; set; }

        [JsonProperty("status")]
        public Status Status { get; set; }

        [JsonProperty("baseAsset")]
        public string BaseAsset { get; set; }

        [JsonProperty("baseAssetPrecision")]
        public long BaseAssetPrecision { get; set; }

        [JsonProperty("quoteAsset")]
        public string QuoteAsset { get; set; }

        [JsonProperty("quotePrecision")]
        public long QuotePrecision { get; set; }

        [JsonProperty("quoteAssetPrecision")]
        public long QuoteAssetPrecision { get; set; }

        [JsonProperty("baseCommissionPrecision")]
        public long BaseCommissionPrecision { get; set; }

        [JsonProperty("quoteCommissionPrecision")]
        public long QuoteCommissionPrecision { get; set; }

        [JsonProperty("orderTypes")]
        public OrderTypes[] OrderTypes { get; set; }

        [JsonProperty("icebergAllowed")]
        public bool IcebergAllowed { get; set; }

        [JsonProperty("ocoAllowed")]
        public bool OcoAllowed { get; set; }

        [JsonProperty("quoteOrderQtyMarketAllowed")]
        public bool QuoteOrderQtyMarketAllowed { get; set; }

        [JsonProperty("isSpotTradingAllowed")]
        public bool IsSpotTradingAllowed { get; set; }

        [JsonProperty("isMarginTradingAllowed")]
        public bool IsMarginTradingAllowed { get; set; }

        [JsonProperty("permissions")]
        public Permission[] Permissions { get; set; }
    }

    public enum Status { BREAK, TRADING };
    public enum OrderTypes { LIMIT, LIMIT_MAKER, MARKET, STOP_LOSS_LIMIT, TAKE_PROFIT_LIMIT };
    public enum Permission { LEVERAGED, MARGIN, SPOT };
    public enum QuoteAsset { AUD, USDS, RUB, BIDR, BKRW, BNB, BRL, BTC, BUSD, BVND, DAI, ETH, EUR, GBP, IDRT, NGN, PAX, TRX, TRY, TUSD, UAH, USDC, USDT, XRP, ZAR };
}
