using MedHub.Application.DTOs;
using MedHub.Application.Helpers;
using MediatR;

namespace MedHub.Application.Queries.DoctorQueries
{
    public class GetAllDoctorsQuery : IRequest<Response<List<DoctorDto>>>
    {
    }
}
