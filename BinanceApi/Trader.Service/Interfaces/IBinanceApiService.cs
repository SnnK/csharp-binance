using Trader.Service.Parameters;
using System.Threading.Tasks;

namespace Trader.Service.Interfaces
{
    public interface IBinanceApiService
    {
        /// <summary>
        /// Exchange Info
        /// </summary>
        /// <param name="exchangeInfoParameter"></param>
        /// <returns></returns>
        Task<dynamic> TradingPairs(ExchangeInfoParameter exchangeInfoParameter);

        /// <summary>
        /// 24hr ticker price change statistics
        /// </summary>
        /// <returns></returns>
        Task<dynamic> Hr24Prices();

        /// <summary>
        /// Kline/candlestick bars for a symbol
        /// </summary>
        /// <param name="candlesticksParameter"></param>
        /// <returns></returns>
        Task<dynamic> Candlesticks(CandlesticksParameter candlesticksParameter);

        /// <summary>
        /// Order book (buy and sell orders)
        /// </summary>
        /// <param name="orderBookParameter"></param>
        /// <returns></returns>
        Task<dynamic> OrderBook(OrderBookParameter orderBookParameter);

        /// <summary>
        /// Recent trades list
        /// </summary>
        /// <param name="latestTradesParameter"></param>
        /// <returns></returns>
        Task<dynamic> LatestTrades(LatestTradesParameter latestTradesParameter);

        /// <summary>
        /// Create new order
        /// </summary>
        /// <param name="orderParamater"></param>
        /// <returns></returns>
        Task<dynamic> NewOrder(NewOrderParamater orderParamater);


        /// <summary>
        /// Get all open orders
        /// </summary>
        /// <param name="symbolParameter"></param>
        /// <returns></returns>
        Task<dynamic> OpenOrders(SymbolParameter symbolParameter);

        /// <summary>
        /// Cancel order
        /// </summary>
        /// <param name="cancelOrderParameter"></param>
        /// <returns></returns>
        Task<dynamic> CancelOrder(CancelOrderParameter cancelOrderParameter);

        /// <summary>
        /// Price ticker
        /// </summary>
        /// <param name="symbolParameter"></param>
        /// <returns></returns>
        Task<dynamic> PriceTicker(SymbolParameter symbolParameter);

        /// <summary>
        /// Get trades.
        /// </summary>
        /// <param name="myTradesParameter"></param>
        /// <returns></returns>
        Task<dynamic> MyTrades(MyTradesParameter myTradesParameter);

        /// <summary>
        /// Get all account orders; active, canceled, or filled.
        /// </summary>
        /// <param name="ordersParameter"></param>
        /// <returns></returns>
        Task<dynamic> AllOrders(AllOrdersParameter ordersParameter);
    }
}
