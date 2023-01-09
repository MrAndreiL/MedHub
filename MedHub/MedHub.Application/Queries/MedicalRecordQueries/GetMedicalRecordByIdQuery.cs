using MedHub.Application.DTOs;
using MedHub.Application.DTOs.Base;
using MedHub.Application.Helpers;
using MediatR;

namespace MedHub.Application.Queries.MedicalRecordQueries
{
    public class GetMedicalRecordByIdQuery : IdDto, IRequest<Response<MedicalRecordDto>>
    {
        public GetMedicalRecordByIdQuery(Guid id) : base(id) { }
    }
}
