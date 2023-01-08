using MedHub.Application.DTOs;
using MedHub.Application.Helpers;
using MedHub.Application.Shared;
using MediatR;

namespace MedHub.Application.Commands.AppointmentCommands
{
    public class DeleteAppointmentCommand : IdCommandQuery, IRequest<Response<AppointmentDto>>
    {
        public DeleteAppointmentCommand(Guid id) : base(id) { }
    }
}
