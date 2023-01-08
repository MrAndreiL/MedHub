using MedHub.Application.DTOs;
using MedHub.Application.Helpers;
using MediatR;

namespace MedHub.Application.Queries.PatientQueries
{
    public class GetAllPatientsQuery : IRequest<Response<List<PatientDto>>>
    {
    }
}
