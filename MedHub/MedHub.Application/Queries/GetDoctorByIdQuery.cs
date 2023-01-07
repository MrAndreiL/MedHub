using MedHub.Application.DTOs;
using MedHub.Application.Helpers;
using MediatR;

namespace MedHub.Application.Queries
{
    public class GetDoctorByIdQuery : IRequest<Response<DoctorDto>>
    {
        public Guid DoctorId { get; }

        public GetDoctorByIdQuery(Guid doctorId)
        {
            DoctorId = doctorId;
        }
    }
}
