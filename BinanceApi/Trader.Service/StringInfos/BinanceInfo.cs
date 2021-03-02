namespace Trader.Service.StringInfos
{
    public class BinanceApi
    {
        public const string BaseUrl = "https://api.binance.com";
        public const string TestnetBaseUrl = "https://testnet.binance.vision";
        public const string ApiKey = "<your_api_key>";
        public const string SecretKey = "<your_secret_key>";
    }

    public class BinanceApiEndpoints
    {
        public const string Ticker = "/api/v3/ticker/24hr";
        public const string OrderBook = "/api/v3/depth";
        public const string LatestTrades = "/api/v3/trades";
        public const string NewOrder = "/api/v3/order";
        public const string OpenOrders = "/api/v3/openOrders";
        public const string CancelOrder = "/api/v3/order";
        public const string PriceTicker = "/api/v3/ticker/price";
        public const string MyTrades = "/api/v3/myTrades";
        public const string AllOrders = "/api/v3/allOrders";
        public const string TradingPairs = "/api/v3/exchangeInfo";
        public const string Candlesticks = "/api/v3/klines";
    }
}
