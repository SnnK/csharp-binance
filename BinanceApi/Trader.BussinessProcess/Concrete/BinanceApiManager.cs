using Trader.BussinessProcess.Interfaces;
using Trader.BussinessProcess.StringInfos;
using Trader.BinanceModels.Concrete;
using Trader.BinanceModels.Enums;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Trader.BussinessProcess.Parameters;
using JsonConverters.Helper;
using Trader.BussinessProcess.Base;

namespace Trader.BussinessProcess.Concrete
{
    public class BinanceApiManager : BaseManager, IBinanceApiService
    {
        private readonly HttpClient _httpClient;
        private readonly IManagerHelper _managerHelper;

        public BinanceApiManager(HttpClient httpClient, IManagerHelper managerHelper)
        {
            _httpClient = httpClient;
            _managerHelper = managerHelper;
            _httpClient.BaseAddress = new Uri(BinanceApi.BaseUrl);
        }

        public async Task<dynamic> TradingPairs(ExchangeInfoParameter exchangeInfoParameter)
        {
            var responseMessage = await CallAsync(_httpClient, HttpMethod.Get, BinanceApiEndpoints.TradingPairs, null);

            if (responseMessage.IsSuccessStatusCode)
            {
                ExchangeInfo message = JsonConvert.DeserializeObject<ExchangeInfo>(await responseMessage.Content.ReadAsStringAsync());

                if (exchangeInfoParameter.Base != null)
                    message.Symbols = message.Symbols.Where(f => f.BaseAsset == exchangeInfoParameter.Base).ToList();

                if (exchangeInfoParameter.Quote != null)
                    message.Symbols = message.Symbols.Where(f => f.QuoteAsset == exchangeInfoParameter.Quote).ToList();

                return message;
            }

            return GetError(await responseMessage.Content.ReadAsStringAsync());
        }

        public async Task<dynamic> Hr24Prices()
        {
            var responseMessage = await CallAsync(_httpClient, HttpMethod.Get, BinanceApiEndpoints.Ticker, null);

            return responseMessage.IsSuccessStatusCode
                ? JsonConvert.DeserializeObject<List<Ticker>>(await responseMessage.Content.ReadAsStringAsync())
                : GetError(await responseMessage.Content.ReadAsStringAsync());
        }

        public async Task<dynamic> PriceTicker(SymbolParameter symbolParameter)
        {
            var Parameters = new List<string>();
            if (!string.IsNullOrWhiteSpace(symbolParameter.Symbol))
                Parameters.Add($"symbol={symbolParameter.Symbol}");

            var responseMessage = await CallAsync(_httpClient, HttpMethod.Get, BinanceApiEndpoints.PriceTicker, Parameters);

            return responseMessage.IsSuccessStatusCode
                ? JsonConvert.DeserializeObject<dynamic>(await responseMessage.Content.ReadAsStringAsync(), new DifferentResponseConverter<PriceTicker>())
                : GetError(await responseMessage.Content.ReadAsStringAsync());
        }

        public async Task<dynamic> OrderBook(OrderBookParameter orderBookParameter)
        {
            var Parameters = new List<string>
            {
                $"symbol={orderBookParameter.Symbol}",
                $"limit={orderBookParameter.Limit}"
            };

            var responseMessage = await CallAsync(_httpClient, HttpMethod.Get, BinanceApiEndpoints.OrderBook, Parameters);

            if (responseMessage.IsSuccessStatusCode)
            {
                var orderBook = JsonConvert.DeserializeObject<OrderBook>(await responseMessage.Content.ReadAsStringAsync());

                foreach (var order in orderBook.Asks)
                {
                    order.Total = Decimal.Multiply(order.Price, order.Quantity);
                }

                foreach (var order in orderBook.Bids)
                {
                    order.Total = Decimal.Multiply(order.Price, order.Quantity);
                }

                orderBook.TotalAsks = orderBook.Asks.Sum(s => s.Total);
                orderBook.TotalBids = orderBook.Bids.Sum(s => s.Total);

                return orderBook;
            }

            return GetError(await responseMessage.Content.ReadAsStringAsync());
        }

        public async Task<dynamic> LatestTrades(LatestTradesParameter latestTradesParameter)
        {
            var Parameters = new List<string>
            {
                $"symbol={latestTradesParameter.Symbol}",
                $"limit={latestTradesParameter.Limit}"
            };

            var responseMessage = await CallAsync(_httpClient, HttpMethod.Get, BinanceApiEndpoints.LatestTrades, Parameters);

            if (responseMessage.IsSuccessStatusCode)
            {
                var latestTrades = JsonConvert.DeserializeObject<List<LatestTrades>>(await responseMessage.Content.ReadAsStringAsync());

                var latestTradesWrapper = new LatestTradesWrapper
                {
                    LatestTrades = latestTrades,
                    Total_both = latestTrades.Sum(s => s.QuoteQty),
                    Total_BuyerMakerFalse = latestTrades.Where(f => !f.IsBuyerMaker).Sum(s => s.QuoteQty),
                    Total_BuyerMakerTrue = latestTrades.Where(f => f.IsBuyerMaker).Sum(s => s.QuoteQty) // alış emirleri uygulanıyor. fiyat aşağı çekiliyor (muhtemel). EN/The buyer made the order. The seller fulfilled it.
                };

                return latestTradesWrapper;
            }

            return GetError(await responseMessage.Content.ReadAsStringAsync());
        }

        public async Task<dynamic> Candlesticks(CandlesticksParameter candlesticksParameter)
        {
            var Parameters = new List<string>
            {
                $"symbol={candlesticksParameter.Symbol}",
                $"interval={candlesticksParameter.Interval}",
                $"limit={candlesticksParameter.Limit}"
            };

            var responseMessage = await CallAsync(_httpClient, HttpMethod.Get, BinanceApiEndpoints.Candlesticks, Parameters);

            return responseMessage.IsSuccessStatusCode
                ? JsonConvert.DeserializeObject<List<Candlestick>>(await responseMessage.Content.ReadAsStringAsync())
                : GetError(await responseMessage.Content.ReadAsStringAsync());
        }

        public async Task<dynamic> NewOrder(NewOrderParamater orderParamater)
        {
            //NOTE: BaseAddress: Testnet
            _httpClient.BaseAddress = new Uri(BinanceApi.TestnetBaseUrl);

            var Parameters = new List<string>
            {
                $"symbol={orderParamater.Symbol}",
                $"side={orderParamater.Side}",
                $"type={orderParamater.Type}",
                $"newClientOrderId={Guid.NewGuid():N}"
            };

            OrderType orderType = (OrderType)Enum.Parse(typeof(OrderType), orderParamater.Type);

            if ((orderType == OrderType.LIMIT || orderType == OrderType.STOP_LOSS_LIMIT
                || orderType == OrderType.TAKE_PROFIT_LIMIT) && string.IsNullOrEmpty(orderParamater.TimeInForce))
                orderParamater.TimeInForce = TimeInForce.GTC.ToString();

            Parameters.Add($"timeInForce={orderParamater.TimeInForce}");

            Parameters.Add($"quantity={orderParamater.Quantity.ToString(culture)}");
            Parameters.Add($"price={orderParamater.Price.ToString(culture)}");

            if (orderParamater.StopPrice > 0.0M)
                Parameters.Add($"stopPrice={orderParamater.StopPrice.ToString(culture)}");

            if (orderParamater.IcebergQty > 0.0M)
                Parameters.Add($"iceburgQty={orderParamater.IcebergQty.ToString(culture)}");

            var responseMessage = await CallAsync(_httpClient, HttpMethod.Post, BinanceApiEndpoints.NewOrder, Parameters, true);

            return responseMessage.IsSuccessStatusCode
                ? JsonConvert.DeserializeObject<OrderResponse>(await responseMessage.Content.ReadAsStringAsync())
                : GetError(await responseMessage.Content.ReadAsStringAsync());
        }

        public async Task<dynamic> OpenOrders(SymbolParameter symbolParameter)
        {
            //NOTE: BaseAddress: Testnet
            _httpClient.BaseAddress = new Uri(BinanceApi.TestnetBaseUrl);

            var Parameters = new List<string>();

            if (!string.IsNullOrWhiteSpace(symbolParameter.Symbol))
                Parameters.Add($"symbol={symbolParameter.Symbol}");

            var responseMessage = await CallAsync(_httpClient, HttpMethod.Get, BinanceApiEndpoints.OpenOrders, Parameters, true);

            return responseMessage.IsSuccessStatusCode
                ? (dynamic)JsonConvert.DeserializeObject<List<OrderResponse>>(await responseMessage.Content.ReadAsStringAsync())
                : GetError(await responseMessage.Content.ReadAsStringAsync());
        }

        public async Task<dynamic> CancelOrder(CancelOrderParameter cancelOrderParameter)
        {
            //NOTE: BaseAddress: Testnet
            _httpClient.BaseAddress = new Uri(BinanceApi.TestnetBaseUrl);

            var Parameters = new List<string>
            {
                $"symbol={cancelOrderParameter.Symbol}",
                $"orderId={cancelOrderParameter.OrderId}"
            };

            if (!string.IsNullOrWhiteSpace(cancelOrderParameter.OrigClientOrderId))
                Parameters.Add($"origClientOrderId={cancelOrderParameter.OrigClientOrderId}");

            var responseMessage = await CallAsync(_httpClient, HttpMethod.Delete, BinanceApiEndpoints.CancelOrder, Parameters, true);

            return responseMessage.IsSuccessStatusCode
                ? JsonConvert.DeserializeObject<OrderResponse>(await responseMessage.Content.ReadAsStringAsync())
                : GetError(await responseMessage.Content.ReadAsStringAsync());
        }

        public async Task<dynamic> MyTrades(MyTradesParameter myTradesParameter)
        {
            //NOTE: BaseAddress: Testnet
            _httpClient.BaseAddress = new Uri(BinanceApi.TestnetBaseUrl);

            var Parameters = new List<string>();

            if (!string.IsNullOrWhiteSpace(myTradesParameter.Symbol))
                Parameters.Add($"symbol={myTradesParameter.Symbol}");

            var responseMessage = await CallAsync(_httpClient, HttpMethod.Get, BinanceApiEndpoints.MyTrades, Parameters, true);

            return responseMessage.IsSuccessStatusCode
                ? (dynamic)JsonConvert.DeserializeObject<List<OrderResponse>>(await responseMessage.Content.ReadAsStringAsync())
                : GetError(await responseMessage.Content.ReadAsStringAsync());
        }

        public async Task<dynamic> AllOrders(AllOrdersParameter ordersParameter)
        {
            //NOTE: BaseAddress: Testnet
            _httpClient.BaseAddress = new Uri(BinanceApi.TestnetBaseUrl);

            var Parameters = new List<string>();

            if (!string.IsNullOrWhiteSpace(ordersParameter.Symbol))
                Parameters.Add($"symbol={ordersParameter.Symbol}");

            var responseMessage = await CallAsync(_httpClient, HttpMethod.Get, BinanceApiEndpoints.AllOrders, Parameters, true);

            return responseMessage.IsSuccessStatusCode
                ? (dynamic)JsonConvert.DeserializeObject<List<OrderResponse>>(await responseMessage.Content.ReadAsStringAsync())
                : GetError(await responseMessage.Content.ReadAsStringAsync());
        }
    }
}