using FluentValidation;
using MedHub.Application.Commands.CabinetCommands;

namespace MedHub.Application.Validators.CabinetValidators
{
    public class CreateCabinetCommandValidator : AbstractValidator<CreateCabinetCommand>
    {
        public CreateCabinetCommandValidator()
        {
            RuleFor(cabinet => cabinet.Address)
                .NotNull()
                .NotEmpty();
            RuleFor(cabinet => cabinet.PhoneNumber)
                .NotNull()
                .NotEmpty()
                .MinimumLength(10).WithMessage("The phone number should have at least 10 digits.")
                .MaximumLength(20).WithMessage("The phone number should have maximum 20 digits.")
                .Must(phoneNumber => phoneNumber.All(char.IsDigit)).WithMessage("The phone number should contain only digits.");
        }
    }
}
