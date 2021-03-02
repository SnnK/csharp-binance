using Trader.Service.Parameters;
using FluentValidation;

namespace Trader.Service.Validations.FluentValidation
{
    public class CancelOrderParameterValidator : AbstractValidator<CancelOrderParameter>
    {
        public CancelOrderParameterValidator()
        {
            RuleFor(I => I.Symbol).NotEmpty().WithMessage("Mandatory parameter 'Symbol' was not sent, was empty/null.").Matches(@"^[A-Z]*$").WithMessage("'Symbol' Only uppercase Characters are allowed. A-Z");
            RuleFor(I => I.OrderId).GreaterThan(0).WithMessage("Mandatory parameter 'OrderId' was not sent, was empty/null.");
        }
    }
}
