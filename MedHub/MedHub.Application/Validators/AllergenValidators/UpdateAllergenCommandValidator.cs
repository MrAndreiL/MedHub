using FluentValidation;
using MedHub.Application.Commands.AllergenCommands;

namespace MedHub.Application.Validators.AllergenValidators
{
    public class UpdateAllergenCommandValidator : AbstractValidator<UpdateAllergenCommand>
    {
        public UpdateAllergenCommandValidator()
        {
            RuleFor(allergen => allergen.Id).NotNull();
            RuleFor(allergen => allergen.Name).NotNull().NotEmpty().WithMessage("something..");
        }
    }
}
