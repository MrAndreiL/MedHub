using FluentValidation;

namespace MedHub.Application.Commands
{
    public class DeleteAllergenCommandValidator : AbstractValidator<DeleteAllergenCommand>
    {
        public DeleteAllergenCommandValidator()
        {
            RuleFor(allergen => allergen.AllergenId).NotNull();
        }
    }
}
