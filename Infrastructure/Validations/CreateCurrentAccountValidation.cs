using Core.Requests;
using FluentValidation;

namespace Infrastructure.Validations;

public class CreateCurrentAccountValidation : AbstractValidator<CreateCurrentAccountRequest>
{
    public CreateCurrentAccountValidation()
    {
        RuleFor(x => x.OperationalLimit)
        .NotNull().WithMessage("OperationalLimit cannot be null")
        .GreaterThan(0).WithMessage("OperationalLimit must be greater than 0");
    }
}
