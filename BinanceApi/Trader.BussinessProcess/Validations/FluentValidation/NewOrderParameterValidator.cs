using Trader.BussinessProcess.Parameters;
using FluentValidation;

namespace Trader.BussinessProcess.Validations.FluentValidation
{
    public class NewOrderParameterValidator : AbstractValidator<NewOrderParamater>
    {
        public NewOrderParameterValidator()
        {
            RuleFor(I => I.Symbol).NotEmpty().WithMessage("Mandatory parameter 'Symbol' was not sent, was empty/null.").Matches(@"^[A-Z]*$").WithMessage("'Symbol' Only uppercase Characters are allowed. A-Z");
            RuleFor(I => I.Side).IsInEnum().WithMessage("Mandatory parameter 'Side' was not sent, was empty/null.");
            RuleFor(I => I.Type).IsInEnum().WithMessage("Mandatory parameter 'Type' was not sent, was empty/null.");
            RuleFor(I => I.Quantity).NotNull().GreaterThan(0).WithMessage("'Quantity' is a mandatory parameter and have to ve greater than 0");
            RuleFor(I => I.Price).NotNull().GreaterThan(0).WithMessage("'Price' is a mandatory parameter and have to ve greater than 0");
        }
    }
}
