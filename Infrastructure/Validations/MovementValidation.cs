using Core.Requests;
using FluentValidation;

namespace Infrastructure.Validations;

public class MovementValidation : AbstractValidator<FilterMovementRequest>
{
    public MovementValidation()
    {
      
        
    }
}