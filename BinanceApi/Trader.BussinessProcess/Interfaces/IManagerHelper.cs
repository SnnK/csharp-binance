using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Trader.BussinessProcess.Models;

namespace Trader.BussinessProcess.Interfaces
{
    public interface IManagerHelper
    {
        /// <summary>
        /// Collect Binance API errors
        /// </summary>
        /// <param name="errValue"></param>
        /// <returns></returns>
        ErrorModel GetError(string errValue);

        /// <summary>
        /// API calls
        /// </summary>
        /// <param name="httpClient"></param>
        /// <param name="method"></param>
        /// <param name="endpoint"></param>
        /// <param name="parameters"></param>
        /// <param name="secure"></param>
        /// <returns></returns>
        Task<HttpResponseMessage> CallAsync(HttpClient httpClient, HttpMethod method,
            string endpoint, List<string> parameters, bool secure = false);

        /// <summary>
        /// Convert decimal to string
        /// </summary>
        /// <param name="decimalValue"></param>
        /// <returns></returns>
        string DecimalToString(decimal decimalValue);
    }
}
