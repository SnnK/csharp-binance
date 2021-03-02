using Trader.Service.Parameters;
using FluentValidation;
using System.Linq;

namespace Trader.Service.Validations.FluentValidation
{
    public class OrderBookParameterValidator : AbstractValidator<OrderBookParameter>
    {
        private readonly int[] allowedLimit = new int[] { 5, 10, 20, 50, 100 };
        public OrderBookParameterValidator()
        {
            RuleFor(I => I.Symbol).NotEmpty().WithMessage("Mandatory parameter 'Symbol' was not sent, was empty/null.").Matches(@"^[A-Z]*$").WithMessage("'Symbol' Only uppercase Characters are allowed. A-Z");
            RuleFor(x => x.Limit).Custom((limit, context) =>
            {
                if (!allowedLimit.Contains(limit))
                {
                    context.AddFailure($"'Limit' Acceptable values: [{string.Join(",", allowedLimit)}]");
                }
            });
        }
    }
}
