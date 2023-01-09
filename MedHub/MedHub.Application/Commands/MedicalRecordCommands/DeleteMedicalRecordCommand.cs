using MedHub.Application.DTOs;
using MedHub.Application.DTOs.Base;
using MedHub.Application.Helpers;
using MediatR;

namespace MedHub.Application.Commands.MedicalRecordCommands
{
    public class DeleteMedicalRecordCommand : IdDto, IRequest<Response<MedicalRecordDto>>
    {
        public DeleteMedicalRecordCommand(Guid id) : base(id) { }
    }
}
