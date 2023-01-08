using FluentValidation;
using MedHub.Application.Commands.AllergenCommands;

namespace MedHub.Application.Validators.AllergenValidators
{
    public class CreateAllergenCommandValidator : AbstractValidator<CreateAllergenCommand>
    {
        public CreateAllergenCommandValidator()
        {
            RuleFor(allergen => allergen.Name).NotEmpty().NotNull();
        }
    }
}
