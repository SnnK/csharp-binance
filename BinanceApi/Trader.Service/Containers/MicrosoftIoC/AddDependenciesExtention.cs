using Trader.Service.Concrete;
using Trader.Service.Validations.FluentValidation;
using Trader.Service.Interfaces;
using Trader.Service.Parameters;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using Trader.Service.Helper;

namespace Trader.Service.Containers.MicrosoftIoC
{
    public static class AddDependenciesExtention
    {
        public static void AddDependencies(this IServiceCollection services)
        {
            services.AddHttpClient<IBinanceApiService, BinanceApiManager>();
            services.AddScoped<IManagerHelper, ManagerHelper>();

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
