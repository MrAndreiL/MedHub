using MedHub.Application.DTOs;
using MedHub.Application.DTOs.Base;
using MedHub.Application.Helpers;
using MediatR;

namespace MedHub.Application.Queries.DoctorQueries
{
    public class GetDoctorByIdQuery : IdDto, IRequest<Response<DoctorDto>>
    {
        public GetDoctorByIdQuery(Guid id) : base(id) { }
    }
}
