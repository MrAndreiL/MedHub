using FluentValidation;
using MedHub.Application.Commands;

namespace MedHub.Application.Validators
{
    public class DeleteAllergenCommandValidator : AbstractValidator<DeleteAllergenCommand>
    {
        public DeleteAllergenCommandValidator()
        {
            RuleFor(allergen => allergen.AllergenId).NotNull();
        }
    }
}
