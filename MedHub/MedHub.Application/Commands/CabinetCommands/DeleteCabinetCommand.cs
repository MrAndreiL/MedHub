using MedHub.Application.DTOs;
using MedHub.Application.Helpers;
using MedHub.Application.Shared;
using MediatR;

namespace MedHub.Application.Commands.CabinetCommands
{
    public class DeleteCabinetCommand : IdCommandQuery, IRequest<Response<CabinetDto>>
    {
        public DeleteCabinetCommand(Guid id) : base(id) { }
    }
}
