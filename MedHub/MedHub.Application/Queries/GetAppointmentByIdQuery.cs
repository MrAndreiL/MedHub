using MedHub.Application.DTOs;
using MedHub.Application.Helpers;
using MediatR;

namespace MedHub.Application.Queries
{
    public class GetAppointmentByIdQuery : IRequest<Response<AppointmentDto>>
    {
        public Guid AppointmentId { get; }
        public GetAppointmentByIdQuery(Guid appointmentId)
        {
            AppointmentId = appointmentId;
        }
    }
}
