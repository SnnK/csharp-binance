using Trader.BussinessProcess.Parameters;
using FluentValidation;

namespace Trader.BussinessProcess.Validations.FluentValidation
{
    public class NewOrderParameterValidator : AbstractValidator<NewOrderParamater>
    {
        public NewOrderParameterValidator()
        {
            RuleFor(I => I.Symbol).NotEmpty().WithMessage("Mandatory parameter 'Symbol' was not sent, was empty/null.").Matches(@"^[A-Z]*$").WithMessage("'Symbol' Only uppercase Characters are allowed. A-Z");
            RuleFor(I => I.Side).NotEmpty().WithMessage("Mandatory parameter 'Side' was not sent, was empty/null.");
            RuleFor(I => I.Type).NotEmpty().WithMessage("Mandatory parameter 'Type' was not sent, was empty/null.");
            RuleFor(I => I.Quantity).Cascade(CascadeMode.Stop).NotNull().GreaterThan(0).WithMessage("'Quantity' is a mandatory parameter and have to ve greater than 0");
            RuleFor(I => I.Price).Cascade(CascadeMode.Stop).NotNull().GreaterThan(0).WithMessage("'Price' is a mandatory parameter and have to ve greater than 0");
        }
    }
}
