using MedHub.Application.DTOs;
using MedHub.Application.Helpers;
using MedHub.Application.Shared;
using MediatR;

namespace MedHub.Application.Queries.AppointmentQueries
{
    public class GetAppointmentByIdQuery : IdCommandQuery, IRequest<Response<AppointmentDto>>
    {
        public GetAppointmentByIdQuery(Guid id) : base(id) { }
    }
}
