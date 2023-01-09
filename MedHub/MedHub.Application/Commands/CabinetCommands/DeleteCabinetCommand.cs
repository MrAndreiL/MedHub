using MedHub.Application.DTOs;
using MedHub.Application.DTOs.Base;
using MedHub.Application.Helpers;
using MediatR;

namespace MedHub.Application.Commands.CabinetCommands
{
    public class DeleteCabinetCommand : IdDto, IRequest<Response<CabinetDto>>
    {
        public DeleteCabinetCommand(Guid id) : base(id) { }
    }
}
