﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Trader.BinanceModels.Concrete;
using Trader.Service.Interfaces;
using Trader.Service.Models;
using Trader.Service.StringInfos;

namespace Trader.Service.Helper
{
    public class ManagerHelper : IManagerHelper
    {
        public string DecimalToString(decimal decimalValue)
        {
            return decimalValue.ToString().Replace(",", ".");
        }

        public ErrorModel GetError(string errValue)
        {
            var getErrorFromBinanceApi = JsonConvert.DeserializeObject<ApiError>(errValue);
            var errModel = new ErrorModel();
            errModel.Errors.Add(getErrorFromBinanceApi.Msg);

            return errModel;
        }

        public async Task<HttpResponseMessage> CallAsync(HttpClient httpClient, HttpMethod method,
            string endpoint, List<string> parameters, bool secure = false)
        {
            string qsValues, hash;
            qsValues = hash = string.Empty;

            if (secure)
            {
                parameters.Add($"timestamp={GetTime()}");
                hash = HMACSignature(parameters, BinanceApi.SecretKey);
                httpClient.DefaultRequestHeaders.Add("X-MBX-APIKEY", BinanceApi.ApiKey);
            }

            if (parameters != null)
                qsValues = string.Join<string>("&", parameters);

            string requestUri = endpoint + (string.IsNullOrWhiteSpace(qsValues) ? "?" : "?" + qsValues + "&") + (secure ? "signature=" + hash : null);

            var request = new HttpRequestMessage(method, requestUri);

            return await httpClient.SendAsync(request).ConfigureAwait(false);
        }

        public string HMACSignature(List<string> messageList, string secretKey)
        {
            string message = string.Join<string>("&", messageList);

            var Encoding = new ASCIIEncoding();

            byte[] keyBytes = Encoding.GetBytes(secretKey);
            var cryptographer = new HMACSHA256(keyBytes);

            byte[] messageBytes = Encoding.GetBytes(message);

            var bytes = cryptographer.ComputeHash(messageBytes);

            return BitConverter.ToString(bytes).Replace("-", "").ToLower();
        }

        public long GetTime()
        {
            var datetimeOffset = new DateTimeOffset(DateTime.UtcNow);
            return datetimeOffset.ToUnixTimeSeconds() * 1000;
        }
    }
}
