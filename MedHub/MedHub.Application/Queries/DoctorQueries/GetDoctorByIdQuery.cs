using MedHub.Application.DTOs;
using MedHub.Application.Helpers;
using MedHub.Application.Shared;
using MediatR;

namespace MedHub.Application.Queries.DoctorQueries
{
    public class GetDoctorByIdQuery : IdCommandQuery, IRequest<Response<DoctorDto>>
    {
        public GetDoctorByIdQuery(Guid id) : base(id) { }
    }
}
