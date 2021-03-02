using Trader.Service.Parameters;
using FluentValidation;

namespace Trader.Service.Validations.FluentValidation
{
    public class SymbolParameterValidator : AbstractValidator<SymbolParameter>
    {
        public SymbolParameterValidator()
        {
            RuleFor(I => I.Symbol).Matches(@"^[A-Z]*$").WithMessage("'Symbol' Only uppercase Characters are allowed. A-Z");
        }
    }
}
