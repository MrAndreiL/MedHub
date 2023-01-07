using FluentValidation;
using MedHub.Application.Commands;

namespace MedHub.Application.Validators
{
    public class DeleteAppointmentCommandValidator : AbstractValidator<DeleteAppointmentCommand>
    {
        public DeleteAppointmentCommandValidator()
        {
            RuleFor(appointment => appointment.AppointmentId).NotNull();
        }
    }
}
