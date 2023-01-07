using MedHub.Application.DTOs;
using MedHub.Application.Helpers;
using MediatR;

namespace MedHub.Application.Commands
{
    public class DeleteAppointmentCommand : IRequest<Response<AppointmentDto>>
    {
        public Guid AppointmentId { get; }

        public DeleteAppointmentCommand(Guid appointmentId)
        {
            AppointmentId = appointmentId;
        }
    }
}
