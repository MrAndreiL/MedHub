using FluentValidation;
using MedHub.Application.Commands.AppointmentCommands;

namespace MedHub.Application.Validators.AppointmentValidators
{
    public class DeleteAppointmentCommandValidator : AbstractValidator<DeleteAppointmentCommand>
    {
        public DeleteAppointmentCommandValidator()
        {
            RuleFor(appointment => appointment.Id).NotNull();
        }
    }
}
