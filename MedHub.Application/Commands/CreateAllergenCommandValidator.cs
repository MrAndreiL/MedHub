using FluentValidation;

namespace MedHub.Application.Commands
{
    public class CreateAllergenCommandValidator : AbstractValidator<CreateAllergenCommand>
    {
        public CreateAllergenCommandValidator()
        {
            RuleFor(allergen => allergen.Name).NotEmpty().NotNull();
        }
    }
}
