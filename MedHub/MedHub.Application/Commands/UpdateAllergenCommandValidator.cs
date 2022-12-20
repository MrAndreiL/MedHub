using FluentValidation;

namespace MedHub.Application.Commands
{
    public class UpdateAllergenCommandValidator : AbstractValidator<UpdateAllergenCommand>
    {
        public UpdateAllergenCommandValidator()
        {
            RuleFor(allergen => allergen.Id).NotNull();
            RuleFor(allergen => allergen.Name).NotNull().NotEmpty();
        }
    }
}
