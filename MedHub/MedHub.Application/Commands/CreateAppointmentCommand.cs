using MedHub.Application.DTOs;
using MedHub.Application.Helpers;
using MediatR;

namespace MedHub.Application.Commands
{
    public class CreateAppointmentCommand : IRequest<Response<AppointmentDto>>
    {
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string? Comment { get; set; }
    }
}
