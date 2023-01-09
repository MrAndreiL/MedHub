using MedHub.Application.DTOs;
using MedHub.Application.DTOs.Base;
using MedHub.Application.Helpers;
using MediatR;

namespace MedHub.Application.Commands.PatientCommands
{
    public class DeletePatientCommand : IdDto, IRequest<Response<PatientDto>>
    {
        public DeletePatientCommand(Guid id) : base(id) { }
    }
}
