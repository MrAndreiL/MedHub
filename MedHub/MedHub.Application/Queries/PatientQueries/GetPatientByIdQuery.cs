using MedHub.Application.DTOs;
using MedHub.Application.Helpers;
using MedHub.Application.Shared;
using MediatR;

namespace MedHub.Application.Queries.PatientQueries
{
    public class GetPatientByIdQuery : IdCommandQuery, IRequest<Response<PatientDto>>
    {
        public GetPatientByIdQuery(Guid id) : base(id) { }
    }
}
