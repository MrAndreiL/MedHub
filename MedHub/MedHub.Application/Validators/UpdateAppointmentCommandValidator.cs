using FluentValidation;
using MedHub.Application.Commands;

namespace MedHub.Application.Validators
{
    public class UpdateAppointmentCommandValidator : AbstractValidator<UpdateAppointmentCommand>
    {
        public UpdateAppointmentCommandValidator()
        {
            RuleFor(appointment => appointment.Id).NotNull();
            RuleFor(appointment => appointment.StartTime).NotNull().NotEmpty();
            RuleFor(appointment => appointment.EndTime).NotNull().NotEmpty()
                .GreaterThanOrEqualTo(appointment => appointment.StartTime);
        }
    }
}
