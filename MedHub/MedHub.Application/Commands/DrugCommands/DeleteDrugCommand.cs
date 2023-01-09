using MedHub.Application.DTOs;
using MedHub.Application.DTOs.Base;
using MedHub.Application.Helpers;
using MediatR;

namespace MedHub.Application.Commands.DrugCommands
{
    public class DeleteDrugCommand : IdDto, IRequest<Response<DrugDto>>
    {
        public DeleteDrugCommand(Guid id) : base(id) { }
    }
}
