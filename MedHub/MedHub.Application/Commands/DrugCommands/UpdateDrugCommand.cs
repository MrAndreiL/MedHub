using MedHub.Application.Commands.Base;
using MedHub.Application.DTOs;
using MedHub.Application.Helpers;
using MediatR;

namespace MedHub.Application.Commands.DrugCommands
{
    public class UpdateDrugCommand : UpdateProductCommand, IRequest<Response<DrugDto>>
    {
        public UpdateDrugCommand(CreateDrugCommand command, Guid drugId)
        {
            Id = drugId;
            Name = command.Name;
            Description = command.Description;
            Price = command.Price;
        }
    }
}
