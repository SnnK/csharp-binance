using Trader.API.Filters;
using Trader.BussinessProcess.Parameters;
using Trader.BussinessProcess.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Trader.BussinessProcess.Models;

namespace Trader.API.Controllers
{
    [Route("api/v1/[controller]/[action]")]
    [ApiController]
    [ValidData]
    public class TraderController : ControllerBase
    {
        private readonly IBinanceApiService _binanceApiService;

        public TraderController(IBinanceApiService binanceApiService)
        {
            _binanceApiService = binanceApiService;
        }

        [HttpGet]
        public async Task<IActionResult> GetTradingPairs([FromQuery] ExchangeInfoParameter exchangeInfoParameter)
        {
            return Result(await _binanceApiService.TradingPairs(exchangeInfoParameter));
        }

        [HttpGet]
        public async Task<IActionResult> Get24hrPrices()
        {
            return Result(await _binanceApiService.Hr24Prices());
        }

        [HttpGet]
        public async Task<IActionResult> GetPriceTicker([FromQuery] SymbolParameter symbolParameter)
        {
            return Result(await _binanceApiService.PriceTicker(symbolParameter));
        }

        [HttpGet]
        public async Task<IActionResult> GetCandlesticks([FromQuery] CandlesticksParameter candlesticksParameter)
        {
            return Result(await _binanceApiService.Candlesticks(candlesticksParameter));
        }

        [HttpGet]
        public async Task<IActionResult> GetOrderBook([FromQuery] OrderBookParameter orderBookQuery)
        {
            return Result(await _binanceApiService.OrderBook(orderBookQuery));
        }

        [HttpGet]
        public async Task<IActionResult> GetLatestTrades([FromQuery] LatestTradesParameter orderBookQuery)
        {
            return Result(await _binanceApiService.LatestTrades(orderBookQuery));
        }

        [HttpGet]
        public async Task<IActionResult> GetOpenOrders([FromQuery] SymbolParameter symbolParameter)
        {
            return Result(await _binanceApiService.OpenOrders(symbolParameter));
        }

        [HttpGet]
        public async Task<IActionResult> GetMyTrades([FromQuery] MyTradesParameter myTradesParameter)
        {
            return Result(await _binanceApiService.MyTrades(myTradesParameter));
        }

        [HttpGet]
        public async Task<IActionResult> GetAllOrders([FromQuery] AllOrdersParameter allOrdersParameter)
        {
            return Result(await _binanceApiService.AllOrders(allOrdersParameter));
        }

        [HttpPost]
        public async Task<IActionResult> NewOrder([FromBody] NewOrderParamater orderParamater)
        {
            return Result(await _binanceApiService.NewOrder(orderParamater));
        }

        [HttpDelete]
        public async Task<IActionResult> CancelOrder([FromBody] CancelOrderParameter cancelOrderParameter)
        {
            return Result(await _binanceApiService.CancelOrder(cancelOrderParameter));
        }

        [ApiExplorerSettings(IgnoreApi = true)]
        private IActionResult Result(dynamic responseMessage)
        {
            return responseMessage is ErrorModel ? BadRequest(responseMessage) : Ok(responseMessage);
        }
    }
}