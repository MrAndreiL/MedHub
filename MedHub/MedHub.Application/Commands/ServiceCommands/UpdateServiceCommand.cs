using MedHub.Application.Commands.Base;
using MedHub.Application.DTOs;
using MedHub.Application.Helpers;
using MediatR;

namespace MedHub.Application.Commands.ServiceCommands
{
    public class UpdateServiceCommand : UpdateProductCommand, IRequest<Response<ServiceDto>>
    {
        public UpdateServiceCommand(CreateServiceCommand command, Guid serviceId)
        {
            Id = serviceId;
            Name = command.Name;
            Description = command.Description;
            Price = command.Price;
        }
    }
}
