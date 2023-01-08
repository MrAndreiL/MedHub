using MedHub.Application.DTOs;
using MedHub.Application.Helpers;
using MediatR;

namespace MedHub.Application.Commands.MedicalRecordCommands
{
    public class UpdateMedicalRecordCommand : IRequest<Response<MedicalRecordDto>>
    {
        public Guid Id { get; set; }
        public string MedicalNote { get; set; } = null!;
        public DateTime RegistrationDate { get; set; }

        public UpdateMedicalRecordCommand(CreateMedicalRecordCommand command, Guid medicalRecordId)
        {
            Id = medicalRecordId;
            MedicalNote = command.MedicalNote;
            RegistrationDate = command.RegistrationDate;
        }
    }
}
