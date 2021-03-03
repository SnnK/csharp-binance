using FluentValidation;
using Trader.BussinessProcess.Parameters;

namespace Trader.BussinessProcess.Validations.FluentValidation
{
    public class AllOrdersParameterValidator : AbstractValidator<AllOrdersParameter>
    {
        public AllOrdersParameterValidator()
        {
            RuleFor(I => I.Symbol).NotEmpty().WithMessage("Mandatory parameter 'Symbol' was not sent, was empty/null.");
        }
    }
}
