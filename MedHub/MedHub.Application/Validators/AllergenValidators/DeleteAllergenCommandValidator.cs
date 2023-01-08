using FluentValidation;
using MedHub.Application.Commands.AllergenCommands;

namespace MedHub.Application.Validators.AllergenValidators
{
    public class DeleteAllergenCommandValidator : AbstractValidator<DeleteAllergenCommand>
    {
        public DeleteAllergenCommandValidator()
        {
            RuleFor(allergen => allergen.Id).NotNull();
        }
    }
}
