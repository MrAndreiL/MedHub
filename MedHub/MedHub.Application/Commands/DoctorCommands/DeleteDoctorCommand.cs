using MedHub.Application.DTOs;
using MedHub.Application.Helpers;
using MedHub.Application.Shared;
using MediatR;

namespace MedHub.Application.Commands.DoctorCommands
{
    public class DeleteDoctorCommand : IdCommandQuery, IRequest<Response<DoctorDto>>
    {
        public DeleteDoctorCommand(Guid id) : base(id) { }
    }
}
