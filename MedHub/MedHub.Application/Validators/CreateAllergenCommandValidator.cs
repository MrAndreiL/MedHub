using FluentValidation;
using MedHub.Application.Commands;

namespace MedHub.Application.Validators
{
    public class CreateAllergenCommandValidator : AbstractValidator<CreateAllergenCommand>
    {
        public CreateAllergenCommandValidator()
        {
            RuleFor(allergen => allergen.Name).NotEmpty().NotNull();
        }
    }
}
