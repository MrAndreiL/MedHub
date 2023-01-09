using MedHub.Application.DTOs;
using MedHub.Application.DTOs.Base;
using MedHub.Application.Helpers;
using MediatR;

namespace MedHub.Application.Queries.MedicalSpecialityQueries
{
    public class GetMedicalSpecialityByIdQuery : IdDto, IRequest<Response<MedicalSpecialityDto>>
    {
        public GetMedicalSpecialityByIdQuery(Guid id) : base(id) { }
    }
}
