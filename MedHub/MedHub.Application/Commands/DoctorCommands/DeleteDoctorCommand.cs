using MedHub.Application.DTOs;
using MedHub.Application.DTOs.Base;
using MedHub.Application.Helpers;
using MediatR;

namespace MedHub.Application.Commands.DoctorCommands
{
    public class DeleteDoctorCommand : IdDto, IRequest<Response<DoctorDto>>
    {
        public DeleteDoctorCommand(Guid id) : base(id) { }
    }
}
