using MedHub.Application.DTOs;
using MedHub.Application.Helpers;
using MediatR;

namespace MedHub.Application.Commands.ServiceCommands
{
    public class UpdateServiceCommand : IRequest<Response<ServiceDto>>
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public decimal Price { get; set; }

        public UpdateServiceCommand(CreateServiceCommand command, Guid drugId)
        {
            Id = drugId;
            Name = command.Name;
            Description = command.Description;
            Price = command.Price;
        }
    }
}
