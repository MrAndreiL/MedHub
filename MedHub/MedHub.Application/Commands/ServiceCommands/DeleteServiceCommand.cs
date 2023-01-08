using MedHub.Application.DTOs;
using MedHub.Application.Helpers;
using MedHub.Application.Shared;
using MediatR;

namespace MedHub.Application.Commands.ServiceCommands
{
    public class DeleteServiceCommand : IdCommandQuery, IRequest<Response<ServiceDto>>
    {
        public DeleteServiceCommand(Guid id) : base(id) { }
    }
}
