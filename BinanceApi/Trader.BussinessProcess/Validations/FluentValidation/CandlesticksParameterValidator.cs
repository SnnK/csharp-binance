using FluentValidation;
using System;
using System.Linq;
using Trader.BussinessProcess.Parameters;

namespace Trader.BussinessProcess.Validations.FluentValidation
{
    public class CandlesticksParameterValidator : AbstractValidator<CandlesticksParameter>
    {
        private readonly string[] allowedIntervals = new string[] { "1m", "3m", "5m", "15m", "30m", "1h", "2h", "4h", "6h", "8h", "12h", "1d", "3d", "1w", "1M" }; 
        public CandlesticksParameterValidator()
        {
            RuleFor(I => I.Symbol).NotEmpty().WithMessage("Mandatory parameter 'Symbol' was not sent, was empty/null.").Matches(@"^[A-Z]*$").WithMessage("'Symbol' Only uppercase Characters are allowed. A-Z");
            RuleFor(I => I.Limit).InclusiveBetween(1, 1000).WithMessage("'Limit' can only be a number in range 1 - 1000");
            RuleFor(I => I.Interval).Custom((limit, context) => {
            
                if(!allowedIntervals.Contains(limit))
                {
                    context.AddFailure($"'Interval' Acceptable values: [{string.Join(",", allowedIntervals)}]");
                }

            });
        }
    }
}
