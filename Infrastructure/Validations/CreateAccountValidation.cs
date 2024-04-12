using Core.Requests;
using FluentValidation;

namespace Infrastructure.Validations;

public class CreateAccountValidation : AbstractValidator<CreateCurrentAccountModel>
{
    public CreateAccountValidation()
    {
        RuleFor(x => x.OperationalLimit)
            .NotNull().WithMessage("Name cannot be null");

    }

   
        
           


    

}
