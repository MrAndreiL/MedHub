using FluentValidation;
using MedHub.Application.Commands;

namespace MedHub.Application.Validators
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
