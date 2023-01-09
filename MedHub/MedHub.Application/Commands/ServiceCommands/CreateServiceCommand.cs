using MedHub.Application.Commands.Base;
using MedHub.Application.DTOs;
using MedHub.Application.Helpers;
using MediatR;

namespace MedHub.Application.Commands.ServiceCommands
{
    public class CreateServiceCommand : CreateProductCommand, IRequest<Response<ServiceDto>> { }
}
