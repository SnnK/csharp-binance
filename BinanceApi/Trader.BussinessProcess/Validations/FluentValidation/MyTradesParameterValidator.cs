﻿using FluentValidation;
using Trader.BussinessProcess.Parameters;

namespace Trader.BussinessProcess.Validations.FluentValidation
{
    public class MyTradesParameterValidator : AbstractValidator<MyTradesParameter>
    {
        public MyTradesParameterValidator()
        {
            RuleFor(I => I.Symbol).NotEmpty().WithMessage("Mandatory parameter 'Symbol' was not sent, was empty/null.");
        }
    }
}
