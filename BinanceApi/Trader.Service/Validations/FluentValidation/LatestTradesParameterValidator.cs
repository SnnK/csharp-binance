using Trader.Service.Parameters;
using FluentValidation;

namespace Trader.Service.Validations.FluentValidation
{
    public class LatestTradesParameterValidator : AbstractValidator<LatestTradesParameter>
    {
        public LatestTradesParameterValidator()
        {
            RuleFor(I => I.Symbol).NotEmpty().WithMessage("Mandatory parameter 'Symbol' was not sent, was empty/null.").Matches(@"^[A-Z]*$").WithMessage("'Symbol' Only uppercase Characters are allowed. A-Z");
            RuleFor(I => I.Limit).InclusiveBetween(1,1000).WithMessage("'Limit' can only be a number in range 1 - 1000");
        }
    }
}
