using MedHub.Application.DTOs;
using MedHub.Application.Helpers;
using MedHub.Application.Shared;
using MediatR;

namespace MedHub.Application.Commands.MedicalSpecialityCommands
{
    public class DeleteMedicalSpecialityCommand : IdCommandQuery, IRequest<Response<MedicalSpecialityDto>>
    {
        public DeleteMedicalSpecialityCommand(Guid id) : base(id) { }
    }
}
