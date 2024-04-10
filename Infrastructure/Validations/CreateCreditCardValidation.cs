using Core.Requests;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Validations
{
    public class CreateCreditCardValidation : AbstractValidator<CreateCreditCardModel>
    {
        public CreateCreditCardValidation()
        {
            RuleFor(cc => cc.CVV)
           .NotNull().WithMessage("CVV cannot be null")
           .NotEmpty().WithMessage("CVV cannot be empty")
           .Length(3).WithMessage("CVV  must have only 3 characters");

            RuleFor(cc => cc.CurrencyId)
                .NotEmpty().WithMessage("CurrencyId cannot be empty");

            RuleFor(cc => cc.CustomerId)
                .NotEmpty().WithMessage("CustomerId cannot be empty");


        }
    }
}
