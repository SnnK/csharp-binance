using FluentValidation;
using Trader.BussinessProcess.Parameters;

namespace Trader.BussinessProcess.Validations.FluentValidation
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
