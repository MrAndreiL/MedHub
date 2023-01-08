using MedHub.Application.DTOs;
using MedHub.Application.Helpers;
using MediatR;

namespace MedHub.Application.Commands.MedicalSpecialityCommands
{
    public class UpdateMedicalSpecialityCommand : IRequest<Response<MedicalSpecialityDto>>
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;

        public UpdateMedicalSpecialityCommand(CreateMedicalSpecialityCommand command, Guid medicalSpecialityId)
        {
            Id = medicalSpecialityId;
            Name = command.Name;
        }
    }
}
