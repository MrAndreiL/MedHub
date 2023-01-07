using MedHub.Application.DTOs;
using MedHub.Application.Helpers;
using MediatR;

namespace MedHub.Application.Commands
{
    public class UpdateAppointmentCommand : IRequest<Response<AppointmentDto>>
    {
        public Guid Id { get; private set; }
        public DateTime StartTime { get; private set; }
        public DateTime EndTime { get; private set; }
        public string? Comment { get; private set; }

        public UpdateAppointmentCommand(CreateAppointmentCommand command, Guid appointmentId)
        {
            Id = appointmentId;
            StartTime = command.StartTime;
            EndTime = command.EndTime;
            Comment = command.Comment;
        }
    }
}
