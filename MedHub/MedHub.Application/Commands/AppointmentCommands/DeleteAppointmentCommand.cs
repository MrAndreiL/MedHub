using MedHub.Application.DTOs;
using MedHub.Application.DTOs.Base;
using MedHub.Application.Helpers;
using MediatR;

namespace MedHub.Application.Commands.AppointmentCommands
{
    public class DeleteAppointmentCommand : IdDto, IRequest<Response<AppointmentDto>>
    {
        public DeleteAppointmentCommand(Guid id) : base(id) { }
    }
}
