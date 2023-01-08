using MedHub.Application.DTOs;
using MedHub.Application.Helpers;
using MedHub.Application.Shared;
using MediatR;

namespace MedHub.Application.Commands.MedicalRecordCommands
{
    public class DeleteMedicalRecordCommand : IdCommandQuery, IRequest<Response<MedicalRecordDto>>
    {
        public DeleteMedicalRecordCommand(Guid id) : base(id) { }
    }
}
