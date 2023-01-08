using MedHub.Application.DTOs;
using MedHub.Application.Helpers;
using MedHub.Application.Shared;
using MediatR;

namespace MedHub.Application.Commands.DrugCommands
{
    public class DeleteDrugCommand : IdCommandQuery, IRequest<Response<DrugDto>>
    {
        public DeleteDrugCommand(Guid id) : base(id) { }
    }
}
