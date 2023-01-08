﻿using MedHub.Application.DTOs;
using MedHub.Application.Helpers;
using MediatR;

namespace MedHub.Application.Commands.PatientCommands
{
    public class UpdatePatientCommand : IRequest<Response<PatientDto>>
    {
        public Guid Id { get; set; }
        public string CNP { get; set; } = null!;
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string PhoneNumber { get; set; } = null!;

        public UpdatePatientCommand(CreatePatientCommand command, Guid patientId)
        {
            Id = patientId;
            CNP = command.CNP;
            FirstName = command.FirstName;
            LastName = command.LastName;
            Email = command.Email;
            PhoneNumber = command.PhoneNumber;
        }
    }
}