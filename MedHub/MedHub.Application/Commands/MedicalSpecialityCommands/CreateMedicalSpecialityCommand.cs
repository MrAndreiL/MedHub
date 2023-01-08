using MedHub.Application.DTOs;
using MedHub.Application.Helpers;
using MediatR;

namespace MedHub.Application.Commands.MedicalSpecialityCommands
{
    public class CreateMedicalSpecialityCommand : IRequest<Response<MedicalSpecialityDto>>
    {
        public string Name { get; set; } = null!;
    }
}
