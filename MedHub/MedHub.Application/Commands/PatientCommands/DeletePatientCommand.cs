using MedHub.Application.DTOs;
using MedHub.Application.Helpers;
using MedHub.Application.Shared;
using MediatR;

namespace MedHub.Application.Commands.PatientCommands
{
    public class DeletePatientCommand : IdCommandQuery, IRequest<Response<PatientDto>>
    {
        public DeletePatientCommand(Guid id) : base(id) { }
    }
}
