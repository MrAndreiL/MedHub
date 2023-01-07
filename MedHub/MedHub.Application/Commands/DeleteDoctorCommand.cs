using MedHub.Application.DTOs;
using MedHub.Application.Helpers;
using MediatR;

namespace MedHub.Application.Commands
{
    public class DeleteDoctorCommand : IRequest<Response<DoctorDto>>
    {
        public Guid DoctorId { get; }

        public DeleteDoctorCommand(Guid doctorId)
        {
            DoctorId = doctorId;
        }
    }
}
