using MedHub.Application.DTOs;
using MedHub.Application.Helpers;
using MediatR;

namespace MedHub.Application.Commands.DoctorCommands
{
    public class UpdateDoctorCommand : IRequest<Response<DoctorDto>>
    {
        public Guid Id { get; set; }
        public string CNP { get; set; } = null!;
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string PhoneNumber { get; set; } = null!;

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
