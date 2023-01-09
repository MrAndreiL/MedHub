using FluentValidation;
using MedHub.Application.Commands.CabinetCommands;

namespace MedHub.Application.Validators.CabinetValidators
{
    public class UpdateCabinetCommandValidator : AbstractValidator<UpdateCabinetCommand>
    {
        public UpdateCabinetCommandValidator()
        {
            /*
            RuleFor(appointment => appointment.Id).NotNull();
            RuleFor(appointment => appointment.StartTime).NotNull().NotEmpty();
            RuleFor(appointment => appointment.EndTime).NotNull().NotEmpty()
                .GreaterThanOrEqualTo(appointment => appointment.StartTime);
            */
        }
    }
}
