using MedHub.Application.DTOs;
using MedHub.Application.DTOs.Base;
using MedHub.Application.Helpers;
using MediatR;

namespace MedHub.Application.Commands.ServiceCommands
{
    public class DeleteServiceCommand : IdDto, IRequest<Response<ServiceDto>>
    {
        public DeleteServiceCommand(Guid id) : base(id) { }
    }
}
