using MedHub.Application.DTOs;
using MedHub.Application.Helpers;
using MediatR;

namespace MedHub.Application.Commands.DrugCommands
{
    public class UpdateDrugCommand : IRequest<Response<DrugDto>>
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public decimal Price { get; set; }

        public UpdateDrugCommand(CreateDrugCommand command, Guid drugId)
        {
            Id = drugId;
            Name = command.Name;
            Description = command.Description;
            Price = command.Price;
        }
    }
}
