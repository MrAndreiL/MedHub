using MedHub.Application.DTOs;
using MedHub.Application.Helpers;
using MedHub.Application.Shared;
using MediatR;

namespace MedHub.Application.Queries.MedicalRecordQueries
{
    public class GetMedicalRecordByIdQuery : IdCommandQuery, IRequest<Response<MedicalRecordDto>>
    {
        public GetMedicalRecordByIdQuery(Guid id) : base(id) { }
    }
}
