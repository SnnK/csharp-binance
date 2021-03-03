using Trader.API.Filters;
using Trader.BussinessProcess.Parameters;
using Trader.BussinessProcess.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Trader.BussinessProcess.Models;

namespace Trader.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    [ValidData]
    public class TraderController : ControllerBase
    {
        private readonly IBinanceApiService _binanceApiService;

        public TraderController(IBinanceApiService binanceApiService)
        {
            _binanceApiService = binanceApiService;
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetTradingPairs([FromQuery] ExchangeInfoParameter exchangeInfoParameter)
        {
            return Result(await _binanceApiService.TradingPairs(exchangeInfoParameter));
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> Get24hrPrices()
        {
            return Result(await _binanceApiService.Hr24Prices());
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetPriceTicker([FromQuery] SymbolParameter symbolParameter)
        {
            return Result(await _binanceApiService.PriceTicker(symbolParameter));
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetCandlesticks([FromQuery] CandlesticksParameter candlesticksParameter)
        {
            return Result(await _binanceApiService.Candlesticks(candlesticksParameter));
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetOrderBook([FromQuery] OrderBookParameter orderBookQuery)
        {
            return Result(await _binanceApiService.OrderBook(orderBookQuery));
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetLatestTrades([FromQuery] LatestTradesParameter orderBookQuery)
        {
            return Result(await _binanceApiService.LatestTrades(orderBookQuery));
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetOpenOrders([FromQuery] SymbolParameter symbolParameter)
        {
            return Result(await _binanceApiService.OpenOrders(symbolParameter));
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetMyTrades([FromQuery] MyTradesParameter myTradesParameter)
        {
            return Result(await _binanceApiService.MyTrades(myTradesParameter));
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetAllOrders([FromQuery] AllOrdersParameter allOrdersParameter)
        {
            return Result(await _binanceApiService.AllOrders(allOrdersParameter));
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> NewOrder([FromBody] NewOrderParamater orderParamater)
        {
            return Result(await _binanceApiService.NewOrder(orderParamater));
        }

        [HttpDelete("[action]")]
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