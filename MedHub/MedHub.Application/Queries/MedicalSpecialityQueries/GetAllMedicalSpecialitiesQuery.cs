using MedHub.Application.DTOs;
using MedHub.Application.Helpers;
using MediatR;

namespace MedHub.Application.Queries.MedicalSpecialityQueries
{
    public class GetAllMedicalSpecialitiesQuery : IRequest<Response<List<MedicalSpecialityDto>>>
    {
    }
}
