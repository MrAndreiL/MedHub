using MedHub.Application.DTOs;
using MedHub.Application.DTOs.Base;
using MedHub.Application.Helpers;
using MediatR;

namespace MedHub.Application.Queries.PatientQueries
{
    public class GetPatientByIdQuery : IdDto, IRequest<Response<PatientDto>>
    {
        public GetPatientByIdQuery(Guid id) : base(id) { }
    }
}
