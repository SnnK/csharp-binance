using FluentValidation;
using Trader.Service.Parameters;

namespace Trader.Service.Validations.FluentValidation
{
    class ExchangeInfoParameterValidator : AbstractValidator<ExchangeInfoParameter>
    {
        public ExchangeInfoParameterValidator()
        {
            RuleFor(I => I.Base).Matches(@"^[A-Z]*$").WithMessage("'Symbol' Only uppercase Characters are allowed. A-Z");
            RuleFor(I => I.Quote).Matches(@"^[A-Z]*$").WithMessage("'Symbol' Only uppercase Characters are allowed. A-Z");
        }
    }
}
