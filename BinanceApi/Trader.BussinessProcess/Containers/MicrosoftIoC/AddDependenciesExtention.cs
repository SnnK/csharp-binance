using Trader.BussinessProcess.Concrete;
using Trader.BussinessProcess.Validations.FluentValidation;
using Trader.BussinessProcess.Interfaces;
using Trader.BussinessProcess.Parameters;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using Trader.BussinessProcess.Base;

namespace Trader.BussinessProcess.Containers.MicrosoftIoC
{
    public static class AddDependenciesExtention
    {
        public static void AddDependencies(this IServiceCollection services)
        {
            services.AddHttpClient<IBinanceApiService, BinanceApiManager>();

            #region fluentvalidation
            services.AddTransient<IValidator<LatestTradesParameter>, LatestTradesParameterValidator>();
            services.AddTransient<IValidator<OrderBookParameter>, OrderBookParameterValidator>();
            services.AddTransient<IValidator<NewOrderParamater>, NewOrderParameterValidator>();
            services.AddTransient<IValidator<SymbolParameter>, SymbolParameterValidator>();
            services.AddTransient<IValidator<AllOrdersParameter>, AllOrdersParameterValidator>();
            services.AddTransient<IValidator<MyTradesParameter>, MyTradesParameterValidator>();
            services.AddTransient<IValidator<ExchangeInfoParameter>, ExchangeInfoParameterValidator>();
            services.AddTransient<IValidator<CandlesticksParameter>, CandlesticksParameterValidator>();
            #endregion
        }
    }
}
