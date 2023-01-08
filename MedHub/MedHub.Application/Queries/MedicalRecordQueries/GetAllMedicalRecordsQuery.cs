using MedHub.Application.DTOs;
using MedHub.Application.Helpers;
using MediatR;

namespace MedHub.Application.Queries.MedicalRecordQueries
{
    public class GetAllMedicalRecordsQuery : IRequest<Response<List<MedicalRecordDto>>>
    {
    }
}
