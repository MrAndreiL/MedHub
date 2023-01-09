using MedHub.Application.DTOs;
using MedHub.Application.DTOs.Base;
using MedHub.Application.Helpers;
using MediatR;

namespace MedHub.Application.Queries.AppointmentQueries
{
    public class GetAppointmentByIdQuery : IdDto, IRequest<Response<AppointmentDto>>
    {
        public GetAppointmentByIdQuery(Guid id) : base(id) { }
    }
}
