using MedHub.Application.Commands.Base;
using MedHub.Application.DTOs;
using MedHub.Application.Helpers;
using MediatR;

namespace MedHub.Application.Commands.PatientCommands
{
    public class UpdatePatientCommand : UpdatePersonCommand, IRequest<Response<PatientDto>>
    {
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
