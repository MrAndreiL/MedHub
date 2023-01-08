using MedHub.Application.DTOs;
using MedHub.Application.Helpers;
using MedHub.Application.Shared;
using MediatR;

namespace MedHub.Application.Queries.MedicalSpecialityQueries
{
    public class GetMedicalSpecialityByIdQuery : IdCommandQuery, IRequest<Response<MedicalSpecialityDto>>
    {
        public GetMedicalSpecialityByIdQuery(Guid id) : base(id) { }
    }
}
