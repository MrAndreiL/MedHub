using FluentValidation;
using MedHub.Application.Commands.CabinetCommands;

namespace MedHub.Application.Validators.CabinetValidators
{
    public class DeleteCabinetCommandValidator : AbstractValidator<DeleteCabinetCommand>
    {
        public DeleteCabinetCommandValidator()
        {
            RuleFor(appointment => appointment.Id).NotNull();
        }
    }
}
