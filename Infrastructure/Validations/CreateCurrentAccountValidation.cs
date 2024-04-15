using Core.DTOs;
using FluentValidation;

namespace Infrastructure.Validations;

public class CreateCurrentAccountValidation : AbstractValidator<CreateCurrentAccountDTO>
{
    public CreateCurrentAccountValidation()
    {
        RuleFor(x => x.OperationalLimit)
        .NotNull().WithMessage("OperationalLimit cannot be null")
        .NotEmpty().WithMessage("OperationalLimit cannot be empty");
    }
}
