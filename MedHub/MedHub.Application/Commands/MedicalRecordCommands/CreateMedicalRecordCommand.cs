using MedHub.Application.DTOs;
using MedHub.Application.Helpers;
using MediatR;

namespace MedHub.Application.Commands.MedicalRecordCommands
{
    public class CreateMedicalRecordCommand : IRequest<Response<MedicalRecordDto>>
    {
        public string MedicalNote { get; set; } = null!;
        public DateTime RegistrationDate { get; set; }
    }
}
