﻿using FluentValidation;
using MedHub.Application.Commands;

namespace MedHub.Application.Validators
{
    public class CreateAppointmentCommandValidator : AbstractValidator<CreateAppointmentCommand>
    {
        public CreateAppointmentCommandValidator()
        {
            RuleFor(appointment => appointment.StartTime).NotEmpty().NotNull();
            RuleFor(appointment => appointment.EndTime).NotEmpty().NotNull()
                .GreaterThanOrEqualTo(appointment => appointment.StartTime);
        }
    }
}