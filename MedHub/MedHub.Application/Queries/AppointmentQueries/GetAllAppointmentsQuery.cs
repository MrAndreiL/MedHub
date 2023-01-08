using MedHub.Application.DTOs;
using MedHub.Application.Helpers;
using MediatR;

namespace MedHub.Application.Queries.AppointmentQueries
{
    public class GetAllAppointmentsQuery : IRequest<Response<List<AppointmentDto>>>
    {
    }
}
