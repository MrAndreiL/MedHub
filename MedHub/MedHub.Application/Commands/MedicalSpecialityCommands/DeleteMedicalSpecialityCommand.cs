using MedHub.Application.DTOs;
using MedHub.Application.DTOs.Base;
using MedHub.Application.Helpers;
using MediatR;

namespace MedHub.Application.Commands.MedicalSpecialityCommands
{
    public class DeleteMedicalSpecialityCommand : IdDto, IRequest<Response<MedicalSpecialityDto>>
    {
        public DeleteMedicalSpecialityCommand(Guid id) : base(id) { }
    }
}
