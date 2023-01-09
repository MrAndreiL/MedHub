using MedHub.Application.Commands.Base;
using MedHub.Application.DTOs;
using MedHub.Application.Helpers;
using MediatR;

namespace MedHub.Application.Commands.DoctorCommands
{
    public class UpdateDoctorCommand : UpdatePersonCommand, IRequest<Response<DoctorDto>>
    {
        public UpdateDoctorCommand(CreateDoctorCommand command, Guid doctorId)
        {
            Id = doctorId;
            CNP = command.CNP;
            FirstName = command.FirstName;
            LastName = command.LastName;
            Email = command.Email;
            PhoneNumber = command.PhoneNumber;
        }
    }
}
